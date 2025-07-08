using Domain.Entities.Approval;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalCommentTests
    {
        private Domain.Entities.Employee.Employee GetValidEmployee()
        {
            return new Domain.Entities.Employee.Employee(
                firstName: "Maria",
                lastName: "Oliveira",
                email: "maria@empresa.com",
                phoneNumber: "11988887777",
                dateOfBirth: new DateTime(1985, 5, 20),
                position: new JobPosition
                {
                    Id = Guid.NewGuid(),
                    Title = "Gerente",
                    Abreviation = "GR",
                    MaximumSalary = 20000,
                    MinimumSalary = 10000,
                    IsActive = true,
                    AllocationRecomendation = 2
                },
                type: EmployeeType.FullTime,
                salary: 15000,
                status: EmployeeStatus.Active,
                departament: new Departament("RH", "RH", "Recursos Humanos")
            );
        }

        [Fact]
        public void Constructor_ValidParameters_ShouldCreateApprovalComment()
        {
            var employee = GetValidEmployee();
            var content = "Comentário válido";

            var comment = new ApprovalComment(content, employee);

            Assert.Equal(content, comment.Content);
            Assert.Equal(employee.Id, comment.CommenterId);
            Assert.Equal(employee, comment.Commenter);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_InvalidContent_ShouldThrowArgumentException(string content)
        {
            var employee = GetValidEmployee();
            Assert.ThrowsAny<ArgumentException>(() => new ApprovalComment(content, employee));
        }

        [Fact]
        public void Constructor_ContentTooLong_ShouldThrowArgumentException()
        {
            var employee = GetValidEmployee();
            var longContent = new string('a', 501);
            Assert.Throws<ArgumentException>(() => new ApprovalComment(longContent, employee));
        }

        [Fact]
        public void Constructor_NullCommenter_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ApprovalComment("Comentário", null));
        }
    }
}