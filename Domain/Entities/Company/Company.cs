using Domain.Common;

namespace Domain.Entities.Company
{
    public class Company : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IdentificationNumber { get; set; }
        public string Abreviation { get; set; }
        public Guid LocalizationId { get; set; }
        public Localization Location { get; set; }


        public Company(string name, string description, string identificationNumber, string abreviation, Localization location)
        {
            Validate(name, description, identificationNumber, abreviation, location);
            Name = name;
            Description = description;
            IdentificationNumber = identificationNumber;
            Abreviation = abreviation;
            Location = location;
            LocalizationId = location.Id;
        }

        public void Validate(string name, string description, string identificationNumber, string abreviation, Localization localization)
        {
            ValidateString(name, 1, 200, nameof(name), "Name must be between 1 and 200 characters.");
            ValidateString(description, 0, 1000, nameof(description), "Description must be up to 1000 characters long.");
            ValidateString(identificationNumber, 1, 50, nameof(identificationNumber), "Identification number must be between 1 and 50 characters.");
            ValidateString(abreviation, 1, 10, nameof(abreviation), "Abreviation must be between 1 and 10 characters.");
            ValidateObject(localization, nameof(localization), "Localization cannot be null.");
        }

    }
}
