using Domain.Entities.Access;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Access
{
    public class AccessLogTests
    {
        private Employee GetValidEmployee()
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "João",
                LastName = "Silva",
                Email = "joao@empresa.com",
                PhoneNumber = "11999999999",
                DateOfBirth = new DateTime(1990, 1, 1),
                PositionID = Guid.NewGuid(),
                Position = new JobPosition
                {
                    Id = Guid.NewGuid(),
                    Title = "Analista",
                    Abreviation = "ANL",
                    MaximumSalary = 10000,
                    MinimumSalary = 5000,
                    IsActive = true,
                    AllocationRecomendation = 1
                },
                Type = EmployeeType.FullTime,
                Salary = 7000,
                IsActive = true,
                Status = EmployeeStatus.Active,
                Departament = new Departament
                {
                    Id = Guid.NewGuid(),
                    Name = "TI",
                    Abreviation = "TI",
                    Description = "Tecnologia da Informação",
                    IsActive = true
                }
            };
        }
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateAccessLog()
        {
            var employee = GetValidEmployee();
            var resource = "Sistema";
            var action = "Login";
            var isSuccess = true;
            var ip = "192.168.0.1";

            var log = new AccessLog(employee, resource, action, isSuccess, ip);

            Assert.Equal(employee, log.Employee);
            Assert.Equal(employee.Id, log.EmployeeId);
            Assert.Equal(resource, log.Resource);
            Assert.Equal(action, log.Action);
            Assert.Equal(isSuccess, log.IsSuccess);
            Assert.Equal(ip, log.IpAddress);
            Assert.NotEqual(default, log.Timestamp);
        }

        [Fact]
        public void Constructor_NullEmployee_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new AccessLog(null, "Sistema", "Login", true, "192.168.0.1"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidResource_ShouldThrowArgumentException(string resource)
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new AccessLog(employee, resource, "Login", true, "192.168.0.1"));
        }
        [Fact]
        public void Constructor_NullResource_ShouldThrowArgumentNullException()
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new AccessLog(employee, null, "Login", true, "192.168.0.1"));

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidAction_ShouldThrowArgumentException(string action)
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new AccessLog(employee, "Sistema", action, true, "192.168.0.1"));
        }

        [Fact]
        public void Constructor_NullAction_ShouldThrowArgumentNullException()
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new AccessLog(employee, "Sistema", null, true, "192.168.0.1"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1.1.1")] // Menor que 7 caracteres
        [InlineData("12345678901234567890123456789012345678901234567890")] // Mais de 45 caracteres
        public void Constructor_InvalidIpAddress_ShouldThrowArgumentException(string ip)
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new AccessLog(employee, "Sistema", "Login", true, ip));
        }
        [Fact]
        public void Constructor_NullIpAddress_ShouldThrowArgumentNullException()
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new AccessLog(employee, "Sistema", "Login", true, null));
        }

        [Fact]
        public void Validate_EmployeeIdEmpty_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            employee.Id = Guid.Empty;
            Assert.Throws<ArgumentException>(() =>
                new AccessLog(employee, "Sistema", "Login", true, "192.168.0.1"));
        }
    }
}
