using Business.Application.Buildings.Commands;
using Business.Application.Buildings.Summaries;
using Business.Application.Payments.Commands;
using Business.Application.Payments.Summaries;
using Business.Common;
using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Payments
{
    public interface IPaymentService
    {
        public Task<Result<Guid, Error>> AddAsync(AddPaymentCommand cmd);
        public Task<Result<bool, Error>> DeleteAsync(Guid paymentId);
        public Task<Result<PaymentSummary, Error>> GetByIdAsync(Guid paymentId);
        public Task<Result<bool, Error>> UpdateAsync(UpdatePaymentCommand cmd);

    }
}
