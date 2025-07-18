﻿using Domain.Common;

namespace Domain.Entities.Approval
{
    public class ApprovalComment : BaseAuditableEntity
    {
        public string Content { get; set; } = string.Empty;
        public Guid CommenterId { get; set; }
        public Employee.Employee Commenter { get; set; } = null!;
    }
}
