using Domain.Common;

namespace Domain.Entities.Access
{
    public class Function : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
