using Domain.Common;

namespace Domain.Entities.Employee
{
    public class Contract : BaseAuditableEntity
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float HourlyRate { get; set; }
        public int HoursPerWeek { get; set; }
        public string Anotations { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpired => EndDate < DateTime.UtcNow;

        public Contract(Employee employee, DateTime startDate, DateTime endDate, float hourlyRate, int hoursPerWeek, string anotations)
        {
            Validate(employee, startDate, endDate, hourlyRate, hoursPerWeek, anotations);
            EmployeeId = employee.Id;
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            HourlyRate = hourlyRate;
            HoursPerWeek = hoursPerWeek;
            Anotations = anotations;
        }

        private void Validate(Employee employee, DateTime startDate, DateTime endDate, float hourlyRate, int hoursPerWeek, string anotations)
        {
            ValidateObject(employee, nameof(Employee));
            if (startDate == DateTime.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(startDate), startDate, "Invalid Start Date");
            }
            if (endDate == DateTime.MinValue)
            {
                throw new ArgumentOutOfRangeException(nameof(endDate), endDate, "Invalid End Date");
            }
            if (hourlyRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hourlyRate), hourlyRate, "Hourly rate must be greater than or equal to 0.");
            }
            if (hoursPerWeek < 0 || hoursPerWeek > 168)
            {
                throw new ArgumentOutOfRangeException(nameof(hoursPerWeek), hoursPerWeek, "Hours per week must be between 0 and 168.");
            }
            ValidateString(anotations, 0, 1000, nameof(anotations), "Annotations must be up to 1000 characters long.");
        }
    }
}
