using RentalManagement.Business.Domain.Entities;

namespace Business.Application.MaintenanceRequests.Commands
{
    public class AddMaintenanceRequestCommand
    {
        public Guid Id { get; private set; }
        public Guid ApartmentId { get; private set; }  // the asset that needs work

        public string Category { get; private set; }   // "Plumbing", "Electrical", ...
        public string? Description { get; private set; }
        public MaintenancePriority Priority { get; private set; }
        public AddMaintenanceRequestCommand(Guid apartmentId, string category, string? description, MaintenancePriority priority)
        {
            Id = Guid.NewGuid();
            ApartmentId = apartmentId;
            Category = category;
            Description = description;
            Priority = priority;
        }
        public MaintenanceRequest ToEntity()
        {
            return new MaintenanceRequest(Id, ApartmentId, Category, Description, Priority);
        }





    }
}