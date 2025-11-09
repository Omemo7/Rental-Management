using Business.Application.Abstractions;
using Business.Application.Leases.Commands;
using Business.Application.Leases.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Leases
{
    public class LeaseService : ILeaseService
    {
        IUnitOfWork _uow;
        ILeaseRepository _leaseRepository;
        public LeaseService(IUnitOfWork uow, ILeaseRepository leaseRepository)
        {
            _uow = uow;
            _leaseRepository = leaseRepository;
        }
        public async Task<Result<Guid, Error>> AddAsync(AddLeaseCommand cmd)
        {
            Lease lease = cmd.ToEntity();

            return await Util.ResultReturnHandler(lease.Id, _uow, async () =>
            {
                await _leaseRepository.AddAsync(lease);
            });

        }

        public async Task<Result<bool, Error>> ChangeRentPaymentFrequency(Guid id, RentPaymentFrequency freq)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }

            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.ChangeRentPaymentFrequency(freq);
                _leaseRepository.Update(lease);
            });
        }

        public async Task<Result<LeaseSummary, Error>> GetByIdAsync(Guid id)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            var summary = LeaseSummary.FromLease(lease);
            return await Util.ResultReturnHandler(summary);

        }
        public async Task<Result<bool, Error>> TerminateLeaseAsync(Guid id)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.Terminate(DateOnly.FromDateTime(DateTime.Now));
                _leaseRepository.Update(lease);
            });
        }

        public async Task<Result<bool, Error>> IsActive(Guid id)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            return await Util.ResultReturnHandler(lease.IsActive);
        }

        public async Task<Result<bool, Error>> IncreaseRentAsync(Guid id, decimal delta)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            var moneyDelta = new RentalManagement.Business.Domain.ValueObjects.Money(delta, lease.RentAmount.Currency);
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.IncreaseRent(moneyDelta);
                _leaseRepository.Update(lease);
            });
        }

        public async Task<Result<bool, Error>> RenewLeaseAsync(Guid id, DateOnly newEndDate)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.Renew(newEndDate);
                _leaseRepository.Update(lease);
            });

        }

        public async Task<Result<bool, Error>> ChangeRentAmountAsync(Guid id, decimal newRentAmount)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            var newRentMoney = new RentalManagement.Business.Domain.ValueObjects.Money(newRentAmount, lease.RentAmount.Currency);
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.ChangeRent(newRentMoney);
                _leaseRepository.Update(lease);
            });
        }

        public async Task<Result<bool, Error>> ChangeLeaseDatesAsync(Guid id, DateOnly newStartDate, DateOnly newEndDate)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.ChangeDates(newStartDate, newEndDate);
                _leaseRepository.Update(lease);
            });
        }

        public async Task<Result<bool, Error>> ChangeDepositAmountAsync(Guid id, decimal newDepositAmount)
        {
            var lease = await _leaseRepository.GetByIdAsync(id);
            if (lease == null)
            {
                return Error.NotFound($"Lease with ID {id} not found.");
            }
            var newDepositMoney = new RentalManagement.Business.Domain.ValueObjects.Money(newDepositAmount, lease.RentAmount.Currency);
            return await Util.ResultReturnHandler(true, _uow, () =>
            {
                lease.ChangeDeposit(newDepositMoney);
                _leaseRepository.Update(lease);
            });
        }
    }
}
