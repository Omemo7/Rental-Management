using Business.Application.MaintenanceRequests.Commands;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Contracts.MaintenanceRequests
{
    public class AddMaintenanceRequestRequest
    {
        
        public Guid ApartmentId { get; set; }  // the asset that needs work

        public string Category { get; set; }   // "Plumbing", "Electrical", ...
        public string? Description { get; set; }
        public MaintenancePriority Priority { get; set; }

        public AddMaintenanceRequestCommand ToCommand()
        {
            return new AddMaintenanceRequestCommand(
                ApartmentId,
                Category,
                Description,
                Priority);
        }

    }
}