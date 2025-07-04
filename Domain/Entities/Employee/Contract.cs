using NERVA.Domain.Common;

namespace NERVA.Domain.Entities.Employee
{
    public class Contract : BaseAuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float HourlyRate { get; set; }
        public int HoursPerWeek { get; set; }
        public string Anotations { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsExpired => EndDate < DateTime.UtcNow;
    }
}
