using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalWorkflow : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string EntityType { get; set; }
        public bool IsActive { get; set; }

        public ApprovalWorkflow(string name, string description, string entityType)
        {
            Validate(name, description, entityType);
            Name = name;
            Description = description;
            EntityType = entityType;
            IsActive = true;
        }

        public void Validate(string name, string description, string entityType)
        {
            ValidateString(name, 1, 200, nameof(name), "Name must be between 1 and 200 characters.");
            ValidateString(description, 0, 1000, nameof(description), "Description must be up to 1000 characters long.");
            ValidateString(entityType, 1, 100, nameof(entityType), "Entity type must be between 1 and 100 characters.");
        }

    }
}
