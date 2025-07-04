
using Domain.Common;
using Domain.Entities.Approval;

namespace Domain.Entities.Approval
{
    public class ApprovalAction : BaseAuditableEntity
    {
        public Guid RequestId { get; set; }
        public ApprovalRequest Request { get; set; } = null!;
        public Guid StepId { get; set; }
        public ApprovalStep Step { get; set; } = null!;
        public Guid ApproverId { get; set; }
        public Employee.Employee Approver { get; set; } = null!;
        public DateTime ActionDate { get; set; } = DateTime.UtcNow;
        public string ActionDetails { get; set; } = string.Empty;
        public bool IsApproved { get; set; } = false;
        public string? RejectionReason { get; set; } = null;
        public List<ApprovalComment> Comments { get; set; } = new List<ApprovalComment>();
    }
}
