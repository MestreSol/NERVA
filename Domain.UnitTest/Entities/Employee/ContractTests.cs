using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Employee
{
    public class ContractTests
    {
        private Domain.Entities.Employee.Employee GetValidEmployee()
        {
            return new Domain.Entities.Employee.Employee(
                firstName: "Maria",
                lastName: "Oliveira",
                email: "maria@empresa.com",
                phoneNumber: "11988887777",
                dateOfBirth: new DateTime(1985, 5, 20),
                position: new JobPosition(
                    title: "Analista",
                    abreviation: "ANL",
                    maximumSalary: 10000,
                    minimumSalary: 5000,
                    allocationRecomendation: 1
                ),
                type: EmployeeType.FullTime,
                salary: 15000,
                status: EmployeeStatus.Active,
                departament: new Departament("RH", "RH", "Recursos Humanos")
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateContract()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow.AddDays(-10);
            var endDate = DateTime.UtcNow.AddDays(10);
            var hourlyRate = 100f;
            var hoursPerWeek = 40;
            var anotations = "Contrato padrão";

            var contract = new Contract(employee, startDate, endDate, hourlyRate, hoursPerWeek, anotations);

            Assert.Equal(employee, contract.Employee);
            Assert.Equal(employee.Id, contract.EmployeeId);
            Assert.Equal(startDate, contract.StartDate);
            Assert.Equal(endDate, contract.EndDate);
            Assert.Equal(hourlyRate, contract.HourlyRate);
            Assert.Equal(hoursPerWeek, contract.HoursPerWeek);
            Assert.Equal(anotations, contract.Anotations);
        }

        [Fact]
        public void Constructor_NullEmployee_ShouldThrowArgumentNullException()
        {
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            Assert.Throws<ArgumentNullException>(() =>
                new Contract(null, startDate, endDate, 100, 40, "Anotação"));
        }

        [Fact]
        public void Constructor_StartDateMinValue_ShouldThrowArgumentOutOfRangeException()
        {
            var employee = GetValidEmployee();
            var endDate = DateTime.UtcNow.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Contract(employee, DateTime.MinValue, endDate, 100, 40, "Anotação"));
        }

        [Fact]
        public void Constructor_EndDateMinValue_ShouldThrowArgumentOutOfRangeException()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow;
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Contract(employee, startDate, DateTime.MinValue, 100, 40, "Anotação"));
        }

        [Fact]
        public void Constructor_NegativeHourlyRate_ShouldThrowArgumentOutOfRangeException()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Contract(employee, startDate, endDate, -1, 40, "Anotação"));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(169)]
        public void Constructor_InvalidHoursPerWeek_ShouldThrowArgumentOutOfRangeException(int hoursPerWeek)
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new Contract(employee, startDate, endDate, 100, hoursPerWeek, "Anotação"));
        }

        [Fact]
        public void Constructor_AnotationsTooLong_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow;
            var endDate = DateTime.UtcNow.AddDays(1);
            var longAnotations = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new Contract(employee, startDate, endDate, 100, 40, longAnotations));
        }

        [Fact]
        public void IsExpired_ShouldReturnTrue_WhenEndDateIsInPast()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow.AddDays(-20);
            var endDate = DateTime.UtcNow.AddDays(-1);
            var contract = new Contract(employee, startDate, endDate, 100, 40, "Anotação");
            Assert.True(contract.IsExpired);
        }

        [Fact]
        public void IsExpired_ShouldReturnFalse_WhenEndDateIsInFuture()
        {
            var employee = GetValidEmployee();
            var startDate = DateTime.UtcNow.AddDays(-1);
            var endDate = DateTime.UtcNow.AddDays(10);
            var contract = new Contract(employee, startDate, endDate, 100, 40, "Anotação");
            Assert.False(contract.IsExpired);
        }
    }
}