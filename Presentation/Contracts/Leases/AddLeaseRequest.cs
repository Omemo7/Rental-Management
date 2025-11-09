using Business.Application.Leases.Commands;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Contracts.Leases
{
    public class AddLeaseRequest
    {

        public Guid ApartmentId { get;  set; }
        public Guid TenantId { get;  set; }

        public DateOnly StartDate { get;  set; }
        public DateOnly? EndDate { get;  set; }
        public RentPaymentFrequency PaymentFrequency { get;  set; }
        public Money RentAmount { get;  set; }
        public Money? SecurityDeposit { get; set; }

        public AddLeaseCommand ToCommand()
        {
            return new AddLeaseCommand(ApartmentId, TenantId, StartDate, RentAmount, SecurityDeposit, PaymentFrequency, EndDate);
        }

    }
}