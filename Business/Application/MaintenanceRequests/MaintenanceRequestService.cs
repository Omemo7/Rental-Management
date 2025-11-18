using Business.Application.Abstractions;
using Business.Application.MaintenanceRequests.Commands;
using Business.Application.MaintenanceRequests.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.MaintenanceRequests
{
    public class MaintenanceRequestService : IMaintenanceRequestService
    {
        IUnitOfWork _unitOfWork;
        IMaintenanceRequestRepository _maintenanceRequestRepository;
        public MaintenanceRequestService(IUnitOfWork unitOfWork, IMaintenanceRequestRepository maintenanceRequestRepository)
        {
            _unitOfWork = unitOfWork;
            _maintenanceRequestRepository = maintenanceRequestRepository;
        }
        public async Task<Result<Guid, Error>> AddAsync(AddMaintenanceRequestCommand cmd)
        {
            var entity = cmd.ToEntity();


            return await Util.ResultReturnHandler(entity.Id, _unitOfWork,async ()=>
            {
                await _maintenanceRequestRepository.AddAsync(entity);
            });
        }

        public async Task<Result<bool, Error>> CompleteAsync(Guid id, Money? laborCost = null, Money? partsCost = null)
        {
            var entity = await _maintenanceRequestRepository.GetByIdAsync(id);
            if (entity is null)
            {
                return Error.NotFound($"Maintenance request with Id {id} not found.");
            }
            return await Util.ResultReturnHandler(true, _unitOfWork, () =>
            {
                entity.Complete(laborCost, partsCost);
                _maintenanceRequestRepository.Update(entity);
            });

        }

        public async Task<Result<bool, Error>> DeleteAsync(Guid id)
        {
            var entity = await _maintenanceRequestRepository.GetByIdAsync(id);
            if (entity is null)
            {
                return Error.NotFound($"Maintenance request with Id {id} not found.");
            }

            return await Util.ResultReturnHandler(true, _unitOfWork, async () =>
            {
                await _maintenanceRequestRepository.DeleteAsync(id);
            });
        }

        public async Task<Result<MaintenanceRequestSummary, Error>> GetByIdAsync(Guid id)
        {
            var entity =  await _maintenanceRequestRepository.GetByIdAsync(id);
            if (entity is null)
            {
                return Error.NotFound($"Maintenance request with Id {id} not found.");
            }

            return await Util.ResultReturnHandler(new MaintenanceRequestSummary(entity));

           
        }
        public async Task<Result<bool, Error>> ScheduleAsync(Guid id, DateTime when)
        {
            var entity = await _maintenanceRequestRepository.GetByIdAsync(id);
            if (entity is null)
            {
                return Error.NotFound($"Maintenance request with Id {id} not found.");
            }
            return await Util.ResultReturnHandler(true, _unitOfWork, () =>
            {
                entity.Schedule(when);
                _maintenanceRequestRepository.Update(entity);
            });

        }
    }
}
