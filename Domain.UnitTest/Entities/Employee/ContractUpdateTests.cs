using Domain.Entities.Employee;
using System;
using Xunit;

namespace Domain.UnitTest.Entities.Employee
{
    public class ContractUpdateTests
    {
        private Domain.Entities.Employee.Employee GetValidEmployee()
        {
            return new Domain.Entities.Employee.Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Ana",
                LastName = "Souza",
                Email = "ana@empresa.com",
                PhoneNumber = "11999999999",
                DateOfBirth = new DateTime(1992, 2, 2),
                PositionID = Guid.NewGuid(),
                Position = new JobPosition
                {
                    Id = Guid.NewGuid(),
                    Title = "Analista",
                    Abreviation = "ANL",
                    MaximumSalary = 12000,
                    MinimumSalary = 4000,
                    IsActive = true,
                    AllocationRecomendation = 1
                },
                Type = Enums.EmployeeType.FullTime,
                Salary = 6000,
                IsActive = true,
                Status = Enums.EmployeeStatus.Active,
                Departament = new Departament("RH", "RH", "Recursos Humanos")
               
            };
        }

        private Contract GetValidContract(Domain.Entities.Employee.Employee employee)
        {
            return new Contract(
                employee,
                DateTime.UtcNow.AddDays(-30),
                DateTime.UtcNow.AddDays(30),
                100,
                40,
                "Contrato válido"
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateContractUpdate()
        {
            var employee = GetValidEmployee();
            var contract = GetValidContract(employee);

            var update = new ContractUpdate(contract, employee);

            Assert.Equal(contract, update.Contract);
            Assert.Equal(contract.Id, update.ContractId);
            Assert.Equal(employee, update.UpdatedBy);
            Assert.Equal(employee.Id, update.UpdatedById);
            Assert.NotEqual(default, update.UpdateDate);
        }

        [Fact]
        public void Constructor_NullContract_ShouldThrowArgumentNullException()
        {
            var employee = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new ContractUpdate(null, employee));
        }

        [Fact]
        public void Constructor_NullUpdatedBy_ShouldThrowArgumentNullException()
        {
            var employee = GetValidEmployee();
            var contract = GetValidContract(employee);
            Assert.Throws<ArgumentNullException>(() =>
                new ContractUpdate(contract, null));
        }
    }
}