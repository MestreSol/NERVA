
using Domain.Common;
using Domain.Entities.Approval;

namespace Domain.Entities.Approval
{
    public class ApprovalAction : BaseAuditableEntity
    {
        public Guid RequestId { get; set; }
        public ApprovalRequest Request { get; set; }
        public Guid StepId { get; set; }
        public ApprovalStep Step { get; set; }
        public Guid ApproverId { get; set; }
        public Employee.Employee Approver { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionDetails { get; set; }
        public bool IsApproved { get; set; }
        public string? RejectionReason { get; set; }
        public List<ApprovalComment> Comments { get; set; }

        public ApprovalAction(ApprovalRequest request, ApprovalStep step, Employee.Employee approver, DateTime actionDate, string actionDetails, bool isApproved, string rejectionReason, List<ApprovalComment>? comments)
        {
            Validate(request, step, approver, actionDate, actionDetails, rejectionReason, comments);
            Request = request;
            RequestId = request.Id;
            Step = step;
            StepId = step.Id;
            Approver = approver;
            ApproverId = approver.Id;
            ActionDate = actionDate;
            ActionDetails = actionDetails;
            IsApproved = isApproved;
            RejectionReason = rejectionReason;
            Comments = comments ?? new List<ApprovalComment>();
        }
        public void Validate(ApprovalRequest request, ApprovalStep step, Employee.Employee approver, DateTime actionDate, string actionDetails, string rejectionReason, List<ApprovalComment> comments)
        {
            ValidateObject(request, nameof(request), "Request cannot be null.");
            ValidateObject(step, nameof(step), "Step cannot be null.");
            ValidateObject(approver, nameof(approver), "Approver cannot be null.");
            ValidateGuid(request.Id, nameof(request.Id), "Request ID must be a valid GUID.");
            ValidateGuid(step.Id, nameof(step.Id), "Step ID must be a valid GUID.");
            ValidateGuid(approver.Id, nameof(approver.Id), "Approver ID must be a valid GUID.");

            if (actionDate == default)
                throw new ArgumentException("Action date must be a valid date.", nameof(actionDate));

            ValidateString(actionDetails, 1, 1000, nameof(actionDetails), "Action details cannot be null or empty and must not exceed 1000 characters.");
            ValidateString(rejectionReason, 1, 500, nameof(rejectionReason), "Rejection reason must not exceed 500 characters.");
        }
    }
}
