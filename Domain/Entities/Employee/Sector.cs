using NERVA.Domain.Common;

namespace NERVA.Domain.Entities.Employee
{
    public class Sector : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
