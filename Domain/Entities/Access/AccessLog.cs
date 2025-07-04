using Domain.Common;

namespace Domain.Entities.Access
{
    public class AccessLog : BaseEntity
    {
        public Employee.Employee Employee { get; set; } = null!;
        public int EmployeeId { get; set; }
        public string Resource { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public string IpAddress { get; set; } = string.Empty;
        public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
    }
}
