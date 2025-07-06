using Domain.Common;

namespace Domain.Entities.Access
{
    public class Permissions : BaseAuditableEntity
    {
        // Descrição da permissão
        public string Description { get; set; }

        // Localizações que podem acessar
        public List<Localization> LocalizationsCanAccess { get; set; }

        // Localizações que não podem acessar
        public List<Localization> LocalizationsCannotAccess { get; set; }

        // Funções que podem acessar
        public List<Function> FunctionsCanAccess { get; set; }

        // Funções que não podem acessar
        public List<Function> FunctionsCannotAccess { get; set; }

        // Construtor da classe Permissions
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
            Validate(); // Valida os dados fornecidos
        }

        // Método para validar as propriedades da classe
        public void Validate()
        {
            if (string.IsNullOrEmpty(Description) || Description.Length > 500)
                throw new ArgumentException("Description must be a non-empty string with a maximum length of 500 characters.", nameof(Description));

            // Valida se há pelo menos uma localização que pode acessar
            ValidateList(LocalizationsCanAccess, nameof(LocalizationsCanAccess));
            // Valida se há pelo menos uma localização que não pode acessar
            ValidateList(LocalizationsCannotAccess, nameof(LocalizationsCannotAccess));
            // Valida se há pelo menos uma função que pode acessar
            ValidateList(FunctionsCanAccess, nameof(FunctionsCanAccess));
            // Valida se há pelo menos uma função que não pode acessar
            ValidateList(FunctionsCannotAccess, nameof(FunctionsCannotAccess));
        }

        // Método auxiliar para validar listas
        private void ValidateList<T>(List<T> list, string paramName)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException($"{paramName} must contain at least one item.", paramName);
        }
    }
}
