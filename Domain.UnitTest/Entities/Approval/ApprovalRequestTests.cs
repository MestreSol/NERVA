using Domain.Entities.Approval;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalRequestTests
    {
        private ApprovalWorkflow GetValidWorkflow()
        {
            return new ApprovalWorkflow(
                name: "Workflow Teste",
                description: "Descrição do workflow",
                entityType: "Tipo"
            )
            {
                Id = Guid.NewGuid(),
                IsActive = true
            };
        }

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
        public void Constructor_ValidParameters_ShouldCreateApprovalRequest()
        {
            var workflow = GetValidWorkflow();
            var requester = GetValidEmployee();
            var details = "Solicitação de aprovação";
            var criticality = RequestCriticality.High;

            var request = new ApprovalRequest(workflow, requester, details, criticality);

            Assert.Equal(workflow, request.Workflow);
            Assert.Equal(workflow.Id, request.WorkflowId);
            Assert.Equal(requester, request.Requester);
            Assert.Equal(requester.Id, request.RequesterId);
            Assert.Equal(details, request.RequestDetails);
            Assert.Equal(criticality, request.Criticality);
            Assert.Equal(ApprovalStatus.Pending, request.Status);
            Assert.NotEqual(default, request.RequestDate);
            Assert.NotNull(request.Steps);
            Assert.Empty(request.Steps);
            Assert.NotNull(request.Comments);
            Assert.Empty(request.Comments);
        }

        [Fact]
        public void Constructor_NullWorkflow_ShouldThrowArgumentNullException()
        {
            var requester = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalRequest(null, requester, "Detalhes", RequestCriticality.Critical));
        }

        [Fact]
        public void Constructor_NullRequester_ShouldThrowArgumentNullException()
        {
            var workflow = GetValidWorkflow();
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalRequest(workflow, null, "Detalhes", RequestCriticality.Critical));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidRequestDetails_ShouldThrowArgumentException(string details)
        {
            var workflow = GetValidWorkflow();
            var requester = GetValidEmployee();
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApprovalRequest(workflow, requester, details, RequestCriticality.Critical));
        }

        [Fact]
        public void Constructor_RequestDetailsTooLong_ShouldThrowArgumentException()
        {
            var workflow = GetValidWorkflow();
            var requester = GetValidEmployee();
            var longDetails = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalRequest(workflow, requester, longDetails, RequestCriticality.Critical));
        }
    }
}