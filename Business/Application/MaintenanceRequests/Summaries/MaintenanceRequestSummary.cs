using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.MaintenanceRequests.Summaries
{
    public class MaintenanceRequestSummary
    {
        public Guid Id { get; private set; }
        public Guid ApartmentId { get; private set; }  // the asset that needs work

        public string Category { get; private set; }   // "Plumbing", "Electrical", ...
        public string? Description { get; private set; }
        public MaintenancePriority Priority { get; private set; }
        public MaintenanceStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? ScheduledAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        // simple costing; you can evolve to line-items later
        public Money? LaborCost { get; private set; }
        public Money? PartsCost { get; private set; }

        public MaintenanceRequestSummary(MaintenanceRequest entity)
        {
            Id = entity.Id;
            ApartmentId = entity.ApartmentId;
            Category = entity.Category;
            Description = entity.Description;
            Priority = entity.Priority;
            Status = entity.Status;
            CreatedAt = entity.CreatedAt;
            ScheduledAt = entity.ScheduledAt;
            CompletedAt = entity.CompletedAt;
            LaborCost = entity.LaborCost;
            PartsCost = entity.PartsCost;
        }
    }
}