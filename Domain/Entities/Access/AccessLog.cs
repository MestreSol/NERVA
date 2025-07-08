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

        public void Validate(string Resource, string Action, string IpAddress, Employee.Employee Employee)
        {
            ValidateString(Resource, 1, 1000, nameof(Resource), "Resource cannot be null or empty and must not exceed 1000 characters.");
            ValidateString(Action, 1, 1000, nameof(Action), "Action cannot be null or empty and must not exceed 1000 characters.");
            
            var ipRegex =
                @"^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$" // IPv4
                + @"|"
                + @"^([0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$"; // IPv6
            ValidateString(IpAddress, 7, 45, nameof(IpAddress), "IpAddress must be a valid IP address (IPv4 or IPv6) and must not exceed 45 characters.");
            if (string.IsNullOrWhiteSpace(IpAddress) ||
                (!System.Net.IPAddress.TryParse(IpAddress, out _) &&
                 !System.Text.RegularExpressions.Regex.IsMatch(IpAddress, ipRegex)))
            {
                throw new ArgumentException("IpAddress must be a valid IP address (IPv4 or IPv6).", nameof(IpAddress));
            }
            if (!System.Net.IPAddress.TryParse(IpAddress, out _))
                throw new ArgumentException("IpAddress must be a valid IP address.", nameof(IpAddress));


            ValidateObject(Employee, nameof(Employee), "Employee cannot be null.");
        }

        public AccessLog(Employee.Employee employee, string resources, string actions, bool isSuccess, string ipAddress)
        {
            Validate(resources,actions,ipAddress,employee);
            Timestamp = DateTimeOffset.UtcNow;
            Employee = employee;
            EmployeeId = employee.Id;
            Resource = resources;
            Action = actions;
            IsSuccess = isSuccess;
            IpAddress = ipAddress;
        }
    }
}
