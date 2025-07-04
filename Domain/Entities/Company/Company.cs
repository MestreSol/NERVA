using Domain.Common;

namespace Domain.Entities.Company
{
    public class Company : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        public Localization? Location { get; set; }
    }
}
