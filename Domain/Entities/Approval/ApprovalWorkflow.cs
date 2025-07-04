using NERVA.Domain.Common;

namespace NERVA.Domain.Entities.Approval
{
    public class ApprovalWorkflow : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}
