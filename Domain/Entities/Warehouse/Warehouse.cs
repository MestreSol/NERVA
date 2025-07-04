
using Domain.Common;

namespace Domain.Entities.Warehouse
{
    public class Warehouse : BaseAuditableEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Localization Localization { get; set; } = new Localization();
        public int MaxCapacity { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
