using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Employee
{
    public class Employee : BaseAuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid PositionId { get; set; }
        public JobPosition Position { get; set; }
        public EmployeeType Type { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public EmployeeStatus Status;
        public Guid DepartamentId { get; set; }
        public Departament Departament { get; set; }

        public Employee(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, JobPosition position, EmployeeType type, decimal salary, EmployeeStatus status, Departament departament)
        {
            Validate(firstName, lastName, email, phoneNumber, dateOfBirth, position, salary, departament);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            PositionId = position.Id;
            Position = position;
            Type = type;
            Salary = salary;
            Status = status;
            switch (status)
            {
                case EmployeeStatus.Active:
                    IsActive = true;
                    break;
                case EmployeeStatus.Inactive:
                case EmployeeStatus.Terminated:
                    IsActive = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
            Status = status;
            DepartamentId = departament.Id;
            Departament = departament;
        }
        public void Validate(string firstName, string lastName, string email, string phoneNumber, DateTime dateOfBirth, JobPosition position, decimal salary, Departament departament)
        {
            ValidateString(firstName, 1, 50, nameof(FirstName), "First name must be between 1 and 50 characters.");
            ValidateString(lastName, 1, 50, nameof(LastName), "Last name must be between 1 and 50 characters.");
            ValidateString(email, 5, 100, nameof(Email), "Email must be between 5 and 100 characters.");
            ValidateString(phoneNumber, 10, 15, nameof(PhoneNumber), "Phone number must be between 10 and 15 characters.");

            if (dateOfBirth > DateTime.UtcNow)
            {
                throw new ArgumentException("Date of birth cannot be in the future.", nameof(dateOfBirth));
            }
            if (dateOfBirth < DateTime.UtcNow.AddYears(-120))
            {
                throw new ArgumentException("Date of birth cannot be more than 120 years ago.", nameof(dateOfBirth));
            }
            ValidateObject(position, nameof(Position), "Position cannot be null.");
            ValidateObject(departament, nameof(Departament), "Departament cannot be null.");
        }
    }
}
