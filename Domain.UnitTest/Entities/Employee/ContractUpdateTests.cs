using Domain.Entities.Employee;
using Domain.Enums;
using System;
using Xunit;

namespace Domain.UnitTest.Entities.Employee
{
    public class ContractUpdateTests
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