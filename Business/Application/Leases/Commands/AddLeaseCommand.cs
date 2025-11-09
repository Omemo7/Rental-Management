using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.Leases.Commands
{
    public class AddLeaseCommand
    {
        
        public Guid ApartmentId { get; private set; }
        public Guid TenantId { get; private set; }

        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public RentPaymentFrequency PaymentFrequency { get; private set; }
        public Money RentAmount { get; private set; }
        public Money? SecurityDeposit { get; private set; }

        public AddLeaseCommand(Guid apartmentId, Guid tenantId, DateOnly startDate, Money rentAmount, Money? securityDeposit = null, RentPaymentFrequency paymentFrequency = RentPaymentFrequency.Monthly, DateOnly? endDate = null)
        {
            ApartmentId = apartmentId;
            TenantId = tenantId;
            StartDate = startDate;
            RentAmount = rentAmount;
            SecurityDeposit = securityDeposit;
            PaymentFrequency = paymentFrequency;
            EndDate = endDate;
        }
        public Lease ToEntity()
        {
            return new Lease(Guid.NewGuid(), ApartmentId, TenantId, StartDate, RentAmount, SecurityDeposit, PaymentFrequency, EndDate);
        }
        }
}