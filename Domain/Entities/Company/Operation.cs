using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Company
{
    public class Operation : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public OperationType Type { get; set; }
        public Guid LocalizationId { get; set; }
        public Localization Localization { get; set; }

        public Operation(string name, string description, string? iconUrl, OperationType type, Company company, Localization localization)
        {
            Validate(name, description, iconUrl, type, company, localization);
            Name = name;
            Description = description;
            IconUrl = iconUrl;
            Type = type;
            Company = company;
            CompanyId = company.Id;
            Localization = localization;
            LocalizationId = localization.Id;
        }

        public void Validate(string name, string description, string? iconUrl, OperationType type, Company company, Localization localization)
        {
            ValidateString(name, 1, 200, nameof(name), "Name must be between 1 and 200 characters.");
            ValidateString(description, 0, 1000, nameof(description), "Description must be up to 1000 characters long.");
            ValidateObject(company, nameof(company), "Company cannot be null.");
            ValidateObject(localization, nameof(localization), "Localization cannot be null.");
            if (iconUrl != null && iconUrl.Length > 500)
            {
                throw new ArgumentOutOfRangeException(nameof(iconUrl), "Icon URL must not exceed 500 characters.");
            }
        }
    }
}
