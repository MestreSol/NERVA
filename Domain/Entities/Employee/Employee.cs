using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Employee
{
    public class Employee : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Guid PositionID { get; set; }
        public JobPosition Position { get; set; } = null!;
        public EmployeeType Type { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public EmployeeStatus Status;
        public Departament Departament { get; set; } = null!;
    }
}
