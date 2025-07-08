using Domain.Entities.Approval;
using Domain.Entities.Employee;
using Domain.Enums;

namespace Domain.UnitTest.Entities.Approval
{
    public class ApprovalCommentTests
    {
        private Employee GetValidEmployee()
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = "Maria",
                LastName = "Oliveira",
                Email = "maria@empresa.com",
                PhoneNumber = "11988887777",
                DateOfBirth = new DateTime(1985, 5, 20),
                PositionID = Guid.NewGuid(),
                Position = new JobPosition
                {
                    Id = Guid.NewGuid(),
                    Title = "Gerente",
                    Abreviation = "GR",
                    MaximumSalary = 20000,
                    MinimumSalary = 10000,
                    IsActive = true,
                    AllocationRecomendation = 2
                },
                Type = EmployeeType.FullTime,
                Salary = 15000,
                IsActive = true,
                Status = EmployeeStatus.Active,
                Departament = new Departament
                {
                    Id = Guid.NewGuid(),
                    Name = "RH",
                    Abreviation = "RH",
                    Description = "Recursos Humanos",
                    IsActive = true
                }
            };
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