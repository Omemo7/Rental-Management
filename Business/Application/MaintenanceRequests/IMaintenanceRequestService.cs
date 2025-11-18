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
    public interface IMaintenanceRequestService
    {
        Task<Result<Guid,Error>> AddAsync(AddMaintenanceRequestCommand cmd);
        Task<Result<MaintenanceRequestSummary, Error>> GetByIdAsync(Guid id);
        Task<Result<bool, Error>> DeleteAsync(Guid id);

        Task<Result<bool, Error>> ScheduleAsync(Guid id, DateTime when);

        Task<Result<bool, Error>> CompleteAsync(Guid id, Money? laborCost = null, Money? partsCost = null);


    }
}
