using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.Leases.Summaries
{
    public class LeaseSummary
    {
        public Guid Id { get; private set; }
        public Guid ApartmentId { get; private set; }
        public Guid TenantId { get; private set; }

        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public RentPaymentFrequency PaymentFrequency { get; private set; }
        public Money RentAmount { get; private set; }
        public Money? SecurityDeposit { get; private set; }

        public static LeaseSummary FromLease(Lease lease)
        {
            return new LeaseSummary
            {
                Id = lease.Id,
                ApartmentId = lease.ApartmentId,
                TenantId = lease.TenantId,
                StartDate = lease.StartDate,
                EndDate = lease.EndDate,
                RentAmount = lease.RentAmount,
                SecurityDeposit = lease.SecurityDeposit,
                PaymentFrequency = lease.PaymentFrequency
            };
        }
    }
}