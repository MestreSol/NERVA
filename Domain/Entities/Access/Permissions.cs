using Domain.Common;

namespace Domain.Entities.Access
{
    public class Permissions : BaseAuditableEntity
    {
        public string Description { get; set; } = string.Empty;
        public List<Localization> LocalizationsCanAccess { get; set; } = new List<Localization>();
        public List<Localization> LocalizationsCannotAccess { get; set; } = new List<Localization>();
        public List<Function> FunctionsCanAccess { get; set; } = new List<Function>();
        public List<Function> FunctionsCannotAccess { get; set; } = new List<Function>();

    }
}
