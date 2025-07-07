using Domain.Common;

namespace Domain.Entities.Access
{
    public class AccessLog : BaseEntity
    {
        public Employee.Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public string Resource { get; set; }
        public string Action { get; set; }
        public bool IsSuccess { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public void Validate()
        {
            ValidateString(Resource, 1, 1000, nameof(Resource), "Resource cannot be null or empty and must not exceed 1000 characters.");
            ValidateString(Action, 1, 1000, nameof(Action), "Action cannot be null or empty and must not exceed 1000 characters.");
            ValidateString(IpAddress, 7, 45, nameof(IpAddress), "IpAddress must be a valid IP address and cannot exceed 45 characters.");
            if (Employee == null)
                throw new ArgumentNullException(nameof(Employee), "Employee cannot be null.");
            if (EmployeeId == Guid.Empty)
                throw new ArgumentException("EmployeeId must be a valid GUID.", nameof(EmployeeId));
            if (Timestamp == default)
                throw new ArgumentException("Timestamp must be a valid DateTimeOffset.", nameof(Timestamp));
        }

        public AccessLog(Employee.Employee employee, string resources, string actions, bool isSuccess, string ipAddress)
        {
            Timestamp = DateTimeOffset.UtcNow;
            Employee = employee ?? throw new ArgumentNullException(nameof(employee), "Employee cannot be null.");
            EmployeeId = employee.Id;
            Resource = resources;
            Action = actions;
            IsSuccess = isSuccess;
            IpAddress = ipAddress;
            Validate();
        }
    }
}
