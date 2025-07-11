﻿using Domain.Common;

namespace Domain.Entities.Access
{
    public class Permissions : BaseAuditableEntity
    {
        public string Description { get; set; }

        public List<Localization> Localizations { get; set; }

        public List<Function> Functions{ get; set; }


        public Permissions(string description,
                           List<Localization> localizationsCanAccess,
                           List<Function> functionsCanAccess
                           )
        {
            Description = description;
            Localizations = localizationsCanAccess;
            Functions = functionsCanAccess;
            Validate(); 
        }

        public void Validate()
        {
            ValidateString(Description, 1, 500, nameof(Description), "Description must be a non-empty string with a maximum length of 500 characters.");
            ValidateList(Localizations, nameof(Localizations));
            ValidateList(Functions, nameof(Functions));
        }

       
    }
}
