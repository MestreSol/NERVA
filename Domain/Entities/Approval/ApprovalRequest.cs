using Domain.Enums;
using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalRequest : BaseAuditableEntity
    {
        public Guid WorkflowId { get; set; }
        public ApprovalWorkflow Workflow { get; set; }
        public Guid RequesterId { get; set; }
        public Employee.Employee Requester { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestDetails { get; set; }
        public int CurrentStep { get; set; } = 0;
        public RequestCriticality Criticality { get; set; }
        public ApprovalStatus Status { get; set; }
        public List<ApprovalStep> Steps { get; set; }
        public List<ApprovalComment> Comments { get; set; }

        public ApprovalRequest(ApprovalWorkflow workflow, Employee.Employee requester, string requestDetails, RequestCriticality criticality)
        {
            Validate(workflow, requester, requestDetails);
            Workflow = workflow;
            WorkflowId = workflow.Id;
            Requester = requester;
            RequesterId = requester.Id;
            RequestDetails = requestDetails;
            Criticality = criticality;
            RequestDate = DateTime.UtcNow;
            Status = ApprovalStatus.Pending;
            Steps = new List<ApprovalStep>();
            Comments = new List<ApprovalComment>();
        }

        public void Validate(ApprovalWorkflow workflow, Employee.Employee requester, string requestDetails)
        {
            ValidateObject(workflow, nameof(workflow), "Workflow cannot be null.");
            ValidateObject(requester, nameof(requester), "Requester cannot be null.");
            ValidateString(requestDetails, 1, 1000, nameof(requestDetails), "Request details must be between 1 and 1000 characters.");
        }

    }
}

