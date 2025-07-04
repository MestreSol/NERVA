using NERVA.Domain.Common;

namespace NERVA.Domain.Entities.Approval
{
    public class ApprovalStep : BaseAuditableEntity
    {
        public Guid WorkflowId { get; set; }
        public ApprovalWorkflow Workflow { get; set; } = null!;
        public int StepOrder { get; set; }
        public string Name { get; set; } = string.Empty;   
        public int RequiredApprovals { get; set; } = 1;
        public bool IsActive { get; set; } = true;
        public List<ApproveGroup> ApproveGroups { get; set; } = new List<ApproveGroup>();
    }
}
