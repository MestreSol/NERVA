using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Places
{
    public class WorkPlace : BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public string Description { get; set; }
        public Localization Localization { get; set; }
        public string Floor { get; set; }
        public string Building { get; set; }
        public int MaxCampacity { get; set; }
        public bool IsActive { get; set; }
        public WorkPlaceType WorkPlaceType { get; set; }

        public WorkPlace(string code, string name, string abreviation, string description, Localization localization, string floor, string building, int maxCampacity, WorkPlaceType workPlaceType)
        {
            Validate(code, name, abreviation, description, localization, floor, building, maxCampacity);
            Code = code;
            Name = name;
            Abreviation = abreviation;
            Description = description;
            Localization = localization;
            Floor = floor;
            Building = building;
            MaxCampacity = maxCampacity;
            IsActive = true;
            WorkPlaceType = workPlaceType;
        }

        public void Validate(string code, string name, string abreviation, string description, Localization localization, string floor, string building, int maxCampacity)
        {
            ValidateString(code, 1, 50, nameof(Code), "Code must be between 1 and 50 characters.");
            ValidateString(name, 1, 100, nameof(Name), "Name must be between 1 and 100 characters.");
            ValidateString(abreviation, 0, 20, nameof(Abreviation), "Abreviation must be between 0 and 20 characters.");
            ValidateString(description, 0, 500, nameof(Description), "Description must be between 0 and 500 characters.");
            if (localization == null)
            {
                throw new ArgumentNullException(nameof(localization), "Localization cannot be null.");
            }
            ValidateString(floor, 0, 50, nameof(Floor), "Floor must be between 0 and 50 characters.");
            ValidateString(building, 0, 100, nameof(Building), "Building must be between 0 and 100 characters.");
            if (maxCampacity <= 0)
            {
                throw new ArgumentException("Max campacity must be greater than zero.", nameof(maxCampacity));
            }
        }
    }
}
