using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalComment : BaseAuditableEntity
    {
        public string Content { get; set; }
        public Guid CommenterId { get; set; }
        public Employee.Employee Commenter { get; set; }

        public ApprovalComment(string content, Employee.Employee commenter)
        {
            Validate(content, commenter);
            Content = content;
            CommenterId = commenter.Id;
            Commenter = commenter;
        }
        public void Validate(string content, Employee.Employee commenter)
        {
            ValidateString(content, 1, 500, nameof(content), "Content must be between 1 and 500 characters.");
            ValidateObject(commenter, nameof(commenter), "Commenter cannot be null.");

        }
    }
}
