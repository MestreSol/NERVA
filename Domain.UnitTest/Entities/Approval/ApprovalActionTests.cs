using Domain.Entities.Approval;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalActionTests
    {
        private ApprovalRequest GetValidRequest()
        {
            ApprovalWorkflow workflow = new ApprovalWorkflow("Workflow", "Descrição", "Tipo")
            {
                Id = Guid.NewGuid(),
                IsActive = true
            };

            var requester = GetValidEmployee();

            return new ApprovalRequest(workflow, requester, "Detalhes", RequestCriticality.Normal)
            {
                Id = Guid.NewGuid(),
                WorkflowId = workflow.Id,
                RequesterId = requester.Id,
                RequestDate = DateTime.UtcNow,
                CurrentStep = 1,
                Status = ApprovalStatus.Pending,
                Steps = new List<ApprovalStep>(),
                Comments = new List<ApprovalComment>()
            };
        }

        private ApprovalStep GetValidStep()
        {
            var workflow = new ApprovalWorkflow("Workflow", "Descrição", "Tipo")
            {
                Id = Guid.NewGuid(),
                IsActive = true
            };

            return new ApprovalStep(workflow, 1, "Aprovação", 1)
            {
                Id = Guid.NewGuid(),
                WorkflowId = workflow.Id,
                Workflow = workflow,
                IsActive = true,
                ApproveGroups = new List<ApproveGroup>()
            };
        }

        private Domain.Entities.Employee.Employee GetValidEmployee()
        {
            return new Domain.Entities.Employee.Employee
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
                    IsActive = true,
                    AllocationRecomendation = 1
                },
                Type = EmployeeType.FullTime,
                IsActive = true,
                Departament = new Departament("TI", "TI", "Tecnologia da Informação")
            };
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateApprovalAction()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            var actionDate = DateTime.UtcNow;
            var actionDetails = "Aprovado";
            var isApproved = true;
            var rejectionReason = "TEST";
            var comments = new List<ApprovalComment>();

            var action = new ApprovalAction(request, step, approver, actionDate, actionDetails, isApproved, rejectionReason, comments);

            Assert.Equal(request, action.Request);
            Assert.Equal(step, action.Step);
            Assert.Equal(approver, action.Approver);
            Assert.Equal(actionDate, action.ActionDate);
            Assert.Equal(actionDetails, action.ActionDetails);
            Assert.Equal(isApproved, action.IsApproved);
            Assert.Equal(rejectionReason, action.RejectionReason);
            Assert.Equal(comments, action.Comments);
        }

        [Fact]
        public void Constructor_NullRequest_ShouldThrowArgumentException()
        {
            var step = GetValidStep();
            var approver = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalAction(null, step, approver, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_NullStep_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var approver = GetValidEmployee();
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalAction(request, null, approver, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_NullApprover_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalAction(request, step, null, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_EmptyRequestId_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            request.Id = Guid.Empty;
            var step = GetValidStep();
            var approver = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_EmptyStepId_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            step.Id = Guid.Empty;
            var approver = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_EmptyApproverId_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            approver.Id = Guid.Empty;
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_DefaultActionDate_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, default, "Ação", true, "", new List<ApprovalComment>()));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_InvalidActionDetails_ShouldThrowArgumentException(string actionDetails)
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, actionDetails, true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_ActionDetailsTooLong_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            var longDetails = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, longDetails, true, "", new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_RejectionReasonTooLong_ShouldThrowArgumentException()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            var longReason = new string('a', 501);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalAction(request, step, approver, DateTime.UtcNow, "Ação", false, longReason, new List<ApprovalComment>()));
        }

        [Fact]
        public void Constructor_NullComments_ShouldSetEmptyList()
        {
            var request = GetValidRequest();
            var step = GetValidStep();
            var approver = GetValidEmployee();
            var action = new ApprovalAction(request, step, approver, DateTime.UtcNow, "Ação", true, "TEST", null);
            Assert.NotNull(action.Comments);
            Assert.Empty(action.Comments);
        }
    }
}