using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Places
{
    public class WorkPlace: BaseAuditableEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Abreviation { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Localization Localization { get; set; } = new Localization();
        public string Floor { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public int MaxCampacity { get; set; } = 0;  
        public bool IsActive { get; set; } = true;
        public WorkPlaceType WorkPlaceType = WorkPlaceType.Office;
    }
}
