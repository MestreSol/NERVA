using Domain.Entities.Approval;
using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApproveGroupTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateApproveGroup()
        {
            var approversIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var groupName = "Grupo de Aprovação";
            var groupDescription = "Descrição do grupo";

            var group = new ApproveGroup(approversIds, groupName, groupDescription);

            Assert.Equal(approversIds, group.ApproversIds);
            Assert.Equal(groupName, group.GroupName);
            Assert.Equal(groupDescription, group.GroupDescription);
            Assert.True(group.IsActive);
            Assert.NotNull(group.Approvers);
            Assert.Empty(group.Approvers);
        }

        [Fact]
        public void Constructor_NullApproversIds_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new ApproveGroup(null, "Grupo", "Descrição"));
        }

        [Fact]
        public void Constructor_EmptyApproversIds_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
                new ApproveGroup(new List<Guid>(), "Grupo", "Descrição"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidGroupName_ShouldThrowArgumentException(string groupName)
        {
            var approversIds = new List<Guid> { Guid.NewGuid() };
            Assert.ThrowsAny<ArgumentException>(() =>
                new ApproveGroup(approversIds, groupName, "Descrição"));
        }

        [Fact]
        public void Constructor_GroupNameTooLong_ShouldThrowArgumentException()
        {
            var approversIds = new List<Guid> { Guid.NewGuid() };
            var longName = new string('a', 201);
            Assert.Throws<ArgumentException>(() =>
                new ApproveGroup(approversIds, longName, "Descrição"));
        }

        [Fact]
        public void Constructor_GroupDescriptionTooLong_ShouldThrowArgumentException()
        {
            var approversIds = new List<Guid> { Guid.NewGuid() };
            var longDescription = new string('a', 1001);
            Assert.Throws<ArgumentException>(() =>
                new ApproveGroup(approversIds, "Grupo", longDescription));
        }
    }
}