using Domain.Common;

namespace Domain.Entities.Access
{
    public class Permissions : BaseAuditableEntity
    {
        public string Description { get; set; }

        public List<Localization> LocalizationsCanAccess { get; set; }

        public List<Localization> LocalizationsCannotAccess { get; set; }

        public List<Function> FunctionsCanAccess { get; set; }

        public List<Function> FunctionsCannotAccess { get; set; }

        public Permissions(string description,
                           List<Localization> localizationsCanAccess,
                           List<Localization> localizationsCannotAccess,
                           List<Function> functionsCanAccess,
                           List<Function> functionsCannotAccess)
        {
            Description = description;
            LocalizationsCanAccess = localizationsCanAccess ?? new List<Localization>();
            LocalizationsCannotAccess = localizationsCannotAccess ?? new List<Localization>();
            FunctionsCanAccess = functionsCanAccess ?? new List<Function>();
            FunctionsCannotAccess = functionsCannotAccess ?? new List<Function>();
            Validate(); 
        }

        public void Validate()
        {
            ValidateString(Description, 1, 500, nameof(Description), "Description must be a non-empty string with a maximum length of 500 characters.");
            ValidateList(LocalizationsCanAccess, nameof(LocalizationsCanAccess));
            ValidateList(LocalizationsCannotAccess, nameof(LocalizationsCannotAccess));
            ValidateList(FunctionsCanAccess, nameof(FunctionsCanAccess));
            ValidateList(FunctionsCannotAccess, nameof(FunctionsCannotAccess));
        }

       
    }
}
