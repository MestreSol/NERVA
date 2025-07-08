
using Domain.Common;

namespace Domain.Entities.Warehouse
{
    public class Warehouse : BaseAuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; } 
        public string Description { get; set; } 
        public Localization Localization { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsActive { get; set; } 

        public Warehouse(string code, string name, string abreviation, string description, Localization localization, int maxCapacity)
        {
            Validate(code, name, abreviation, description, localization, maxCapacity);
            Code = code;
            Name = name;
            Abreviation = abreviation;
            Description = description;
            Localization = localization;
            MaxCapacity = maxCapacity;
            IsActive = true;
        }

        public void Validate(string code, string name, string abreviation, string description, Localization localization, int maxCapacity)
        {
            ValidateString(code, 1, 50, nameof(Code), "Code must be between 1 and 50 characters.");
            ValidateString(name, 1, 100, nameof(Name), "Name must be between 1 and 100 characters.");
            ValidateString(abreviation, 0, 20, nameof(Abreviation), "Abreviation must be between 0 and 20 characters.");
            ValidateString(description, 0, 500, nameof(Description), "Description must be between 0 and 500 characters.");
            if (localization == null)
            {
                throw new ArgumentNullException(nameof(localization), "Localization cannot be null.");
            }
            if (maxCapacity <= 0)
            {
                throw new ArgumentException("Max capacity must be greater than zero.", nameof(maxCapacity));
            }
        }
    }
}
