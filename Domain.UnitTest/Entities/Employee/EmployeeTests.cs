using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Employee
{
    public class EmployeeTests
    {
        private JobPosition GetValidJobPosition()
        {
            return new JobPosition
            {
                Id = Guid.NewGuid(),
                Title = "Desenvolvedor",
                Abreviation = "DEV",
                MaximumSalary = 15000,
                MinimumSalary = 5000,
                IsActive = true,
                AllocationRecomendation = 1
            };
        }

        private Departament GetValidDepartament()
        {
            return new Departament(
                name: "TI",
                abreviation: "TI",
                description: "Tecnologia da Informação"
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateEmployee()
        {
            var firstName = "Lucas";
            var lastName = "Ferreira";
            var email = "lucas@empresa.com";
            var phoneNumber = "11999999999";
            var dateOfBirth = DateTime.UtcNow.AddYears(-30);
            var position = GetValidJobPosition();
            var type = EmployeeType.FullTime;
            var salary = 8000m;
            var status = EmployeeStatus.Active;
            var departament = GetValidDepartament();

            var employee = new Domain.Entities.Employee.Employee(firstName, lastName, email, phoneNumber, dateOfBirth, position, type, salary, status, departament);

            Assert.Equal(firstName, employee.FirstName);
            Assert.Equal(lastName, employee.LastName);
            Assert.Equal(email, employee.Email);
            Assert.Equal(phoneNumber, employee.PhoneNumber);
            Assert.Equal(dateOfBirth, employee.DateOfBirth);
            Assert.Equal(position, employee.Position);
            Assert.Equal(type, employee.Type);
            Assert.Equal(salary, employee.Salary);
            Assert.Equal(status, employee.Status);
            Assert.Equal(departament, employee.Departament);
            Assert.Equal(departament.Id, employee.DepartamentId);
            Assert.Equal(position.Id, employee.PositionId);
            Assert.True(employee.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidFirstName_ShouldThrowArgumentException(string firstName)
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee(firstName, "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_FirstNameTooLong_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var longName = new string('a', 51);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee(longName, "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidLastName_ShouldThrowArgumentException(string lastName)
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", lastName, "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_LastNameTooLong_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var longName = new string('a', 51);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", longName, "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("a@b")]
        public void Constructor_InvalidEmail_ShouldThrowArgumentException(string email)
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", email, "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_EmailTooLong_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var longEmail = new string('a', 101) + "@empresa.com";
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", longEmail, "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123456789")]
        public void Constructor_InvalidPhoneNumber_ShouldThrowArgumentException(string phone)
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            Assert.ThrowsAny<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", phone, DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_PhoneNumberTooLong_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var longPhone = new string('1', 16);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", longPhone, DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_DateOfBirthInFuture_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var futureDate = DateTime.UtcNow.AddDays(1);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", futureDate, position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_DateOfBirthTooOld_ShouldThrowArgumentException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var oldDate = DateTime.UtcNow.AddYears(-121);
            Assert.Throws<ArgumentException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", oldDate, position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_NullPosition_ShouldThrowArgumentNullException()
        {
            var departament = GetValidDepartament();
            Assert.Throws<ArgumentNullException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), null, EmployeeType.FullTime, 5000, EmployeeStatus.Active, departament));
        }

        [Fact]
        public void Constructor_NullDepartament_ShouldThrowArgumentNullException()
        {
            var position = GetValidJobPosition();
            Assert.Throws<ArgumentNullException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, EmployeeStatus.Active, null));
        }

        [Theory]
        [InlineData(EmployeeStatus.Active, true)]
        [InlineData(EmployeeStatus.Inactive, false)]
        [InlineData(EmployeeStatus.Terminated, false)]
        public void Constructor_Status_ShouldSetIsActiveCorrectly(EmployeeStatus status, bool expectedIsActive)
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var employee = new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, status, departament);
            Assert.Equal(expectedIsActive, employee.IsActive);
        }

        [Fact]
        public void Constructor_InvalidStatus_ShouldThrowArgumentOutOfRangeException()
        {
            var position = GetValidJobPosition();
            var departament = GetValidDepartament();
            var invalidStatus = (EmployeeStatus)999;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Domain.Entities.Employee.Employee("João", "Silva", "email@empresa.com", "11999999999", DateTime.UtcNow.AddYears(-30), position, EmployeeType.FullTime, 5000, invalidStatus, departament));
        }
    }
}