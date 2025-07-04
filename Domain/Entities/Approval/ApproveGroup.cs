using NERVA.Domain.Common;

namespace NERVA.Domain.Entities.Approval
{
    public class ApproveGroup : BaseAuditableEntity
    {
        public List<Guid> ApproversIds { get; set; } = new List<Guid>();
        public List<Employee.Employee> Approvers { get; set; } = new List<Employee.Employee>();
        public string GroupName { get; set; } = string.Empty;
        public string GroupDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
