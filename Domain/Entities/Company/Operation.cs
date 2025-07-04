using NERVA.Domain.Common;
using NERVA.Domain.Enums;

namespace NERVA.Domain.Entities.Company
{
    public class Operation : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public OperationType Type { get; set; } = OperationType.Unknown;
        public Localization Localization
    }
}
