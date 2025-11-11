using Business.Application.Abstractions;
using Business.Application.Payments.Commands;
using Business.Application.Payments.Summaries;
using Business.Application.Tenants.Commands;
using Business.Application.Tenants.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Payments
{
    public class PaymentService:IPaymentService
    {
        IUnitOfWork _uow;
        IPaymentRepository _paymentRepository;
        public PaymentService(IUnitOfWork uow, IPaymentRepository pr)
        {
            _uow = uow;
            _paymentRepository = pr;
        }
        public async Task<Result<Guid, Error>> AddAsync(AddPaymentCommand cmd)
        {
            Payment payment = cmd.ToEntity();

            return await Util.ResultReturnHandler(payment.Id, _uow, async () => await _paymentRepository.AddAsync(payment));


        }

        public async Task<Result<bool, Error>> DeleteAsync(Guid paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null) return Error.NotFound($"Payment with ID {paymentId} not found.");

            return await Util.ResultReturnHandler(true, _uow, async () => await _paymentRepository.DeleteAsync(paymentId));
        }

        public async Task<Result<PaymentSummary, Error>> GetByIdAsync(Guid paymentId)
        {
            var payment = await _paymentRepository.GetByIdAsync(paymentId);
            if (payment == null) return Error.NotFound($"Payment with ID {paymentId} not found.");

            return await Util.ResultReturnHandler(PaymentSummary.FromPayment(payment));

        }

        public async Task<Result<PaymentSummary, Error>> UpdateAsync(UpdatePaymentCommand cmd)
        {
            Payment? payment = await _paymentRepository.GetByIdAsync(cmd.Id);
            if (payment == null) return Error.NotFound($"Payment with ID {cmd.Id} not found.");

           

            return await Util.ResultReturnHandler(PaymentSummary.FromPayment(payment), _uow, () =>
            {
                payment.Update(
               cmd.PaidAt,
               cmd.Amount,
               cmd.Method,
               cmd.Notes
               );
                _paymentRepository.Update(payment);
            });
        }
    }
}
