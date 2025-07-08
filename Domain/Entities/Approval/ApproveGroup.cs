using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApproveGroup : BaseAuditableEntity
    {
        public List<Guid> ApproversIds { get; set; }
        public List<Employee.Employee> Approvers { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public bool IsActive { get; set; }

        public ApproveGroup(List<Guid> approversIds, string groupName, string groupDescription)
        {
            Validate(approversIds, groupName, groupDescription);
            ApproversIds = approversIds;
            GroupName = groupName;
            GroupDescription = groupDescription;
            IsActive = true;
            Approvers = new List<Employee.Employee>();
        }

        public void Validate(List<Guid> approversIds, string groupName, string groupDescription)
        {
            if (approversIds == null || approversIds.Count == 0)
            {
                throw new ArgumentException("Approvers IDs cannot be null or empty.", nameof(approversIds));
            }
            ValidateString(groupName, 1, 200, nameof(groupName), "Group name must be between 1 and 200 characters.");
            ValidateString(groupDescription, 0, 1000, nameof(groupDescription), "Group description must be up to 1000 characters long.");
        }
    }
}
