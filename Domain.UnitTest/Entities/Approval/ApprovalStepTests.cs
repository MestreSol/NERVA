
using Domain.Entities.Approval;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalStepTests
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

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateApprovalStep()
        {
            var workflow = GetValidWorkflow();
            var stepOrder = 1;
            var name = "Aprovação Inicial";
            var requiredApprovals = 2;

            var step = new ApprovalStep(workflow, stepOrder, name, requiredApprovals);

            Assert.Equal(workflow, step.Workflow);
            Assert.Equal(workflow.Id, step.WorkflowId);
            Assert.Equal(stepOrder, step.StepOrder);
            Assert.Equal(name, step.Name);
            Assert.Equal(requiredApprovals, step.RequiredApprovals);
            Assert.True(step.IsActive);
            Assert.NotNull(step.ApproveGroups);
            Assert.Empty(step.ApproveGroups);
        }

        [Fact]
        public void Constructor_NullWorkflow_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new ApprovalStep(null, 1, "Nome", 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_InvalidStepOrder_ShouldThrowArgumentOutOfRangeException(int stepOrder)
        {
            var workflow = GetValidWorkflow();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new ApprovalStep(workflow, stepOrder, "Nome", 1));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            var workflow = GetValidWorkflow();
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApprovalStep(workflow, 1, name, 1));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var workflow = GetValidWorkflow();
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalStep(workflow, 1, longName, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void Constructor_InvalidRequiredApprovals_ShouldThrowArgumentOutOfRangeException(int requiredApprovals)
        {
            var workflow = GetValidWorkflow();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new ApprovalStep(workflow, 1, "Nome", requiredApprovals));
        }
    }
}
