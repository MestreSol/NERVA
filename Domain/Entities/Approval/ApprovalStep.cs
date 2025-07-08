using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalStep : BaseAuditableEntity
    {
        public Guid WorkflowId { get; set; }
        public ApprovalWorkflow Workflow { get; set; }
        public int StepOrder { get; set; }
        public string Name { get; set; }  
        public int RequiredApprovals { get; set; }
        public bool IsActive { get; set; }
        public List<ApproveGroup> ApproveGroups { get; set; }

        public ApprovalStep(ApprovalWorkflow workflow, int stepOrder, string name, int requiredApprovals)
        {
            Validate(workflow, stepOrder, name, requiredApprovals);
            Workflow = workflow;
            WorkflowId = workflow.Id;
            StepOrder = stepOrder;
            Name = name;
            RequiredApprovals = requiredApprovals;
            IsActive = true;
            ApproveGroups = new List<ApproveGroup>();
        }

        public void Validate(ApprovalWorkflow workflow, int stepOrder, string name, int requiredApprovals)
        {
            ValidateObject(workflow, nameof(workflow), "Workflow cannot be null.");
            if (stepOrder < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(stepOrder), "Step order must be greater than 0.");
            }
            ValidateString(name, 1, 200, nameof(name), "Name must be between 1 and 200 characters.");
            if(requiredApprovals < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(requiredApprovals), "Required approvals must be greater than 0.");
            }
        }
    }
}
