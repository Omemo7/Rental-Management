using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Contracts.MaintenanceRequests
{
    public class CompleteMaintenanceRequestRequest
    {
        public Money? LaborCost { get; set; }
        public Money? PartsCost { get; set; }
    }
}