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
    public interface ILeaseService
    {

        public Task<Result<Guid, Error>> AddAsync(AddLeaseCommand cmd);
        public Task<Result<LeaseSummary, Error>> GetByIdAsync(Guid id);

        public Task<Result<bool, Error>> TerminateLeaseAsync(Guid id);
         
        public Task<Result<bool, Error>> RenewLeaseAsync(Guid id, DateOnly newEndDate);

        public Task<Result<bool, Error>> IsActive(Guid id);

        public Task<Result<bool, Error>> ChangeRentAmountAsync(Guid id, decimal newRentAmount);

        public Task<Result<bool, Error>> ChangeLeaseDatesAsync(Guid id, DateOnly newStartDate, DateOnly newEndDate);

        public Task<Result<bool, Error>> ChangeRentPaymentFrequency(Guid id,RentPaymentFrequency freq);

        public Task<Result<bool,Error>> ChangeDepositAmountAsync(Guid id,decimal newDepositAmount);

        public Task<Result<bool, Error>> IncreaseRentAsync(Guid Id,decimal delta);


    }
}
