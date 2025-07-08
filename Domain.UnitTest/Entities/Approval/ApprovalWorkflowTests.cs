using Domain.Entities.Approval;
using System;
using Xunit;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalWorkflowTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateApprovalWorkflow()
        {
            var name = "Fluxo de Aprova��o";
            var description = "Descri��o do fluxo";
            var entityType = "Requisi��o";

            var workflow = new ApprovalWorkflow(name, description, entityType);

            Assert.Equal(name, workflow.Name);
            Assert.Equal(description, workflow.Description);
            Assert.Equal(entityType, workflow.EntityType);
            Assert.True(workflow.IsActive);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string name)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApprovalWorkflow(name, "Descri��o", "Tipo"));
        }

        [Fact]
        public void Constructor_NameTooLong_ShouldThrowArgumentException()
        {
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalWorkflow(longName, "Descri��o", "Tipo"));
        }

        [Fact]
        public void Constructor_DescriptionTooLong_ShouldThrowArgumentException()
        {
            var longDescription = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalWorkflow("Nome", longDescription, "Tipo"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidEntityType_ShouldThrowArgumentException(string entityType)
        {
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApprovalWorkflow("Nome", "Descri��o", entityType));
        }

        [Fact]
        public void Constructor_EntityTypeTooLong_ShouldThrowArgumentException()
        {
            var longEntityType = new string('b', 101);
            Assert.Throws<ArgumentException>(() =>
                new ApprovalWorkflow("Nome", "Descri��o", longEntityType));
        }
    }
}