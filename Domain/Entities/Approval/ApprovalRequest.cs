using Domain.Enums;
using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalRequest : BaseAuditableEntity
    {
        public Guid WorkflowId { get; set; }
        public ApprovalWorkflow Workflow { get; set; } = null!;
        public Guid RequesterId { get; set; }
        public Employee.Employee Requester { get; set; } = null!;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string RequestDetails { get; set; } = string.Empty;
        public int CurrentStep { get; set; } = 0;
        public RequestCriticality Criticality { get; set; } = RequestCriticality.Normal;
        public ApprovalStatus Status { get; set; } = ApprovalStatus.Pending;
        public List<ApprovalStep> Steps { get; set; } = new List<ApprovalStep>();
        public List<ApprovalComment> Comments { get; set; } = new List<ApprovalComment>();

    }
}
