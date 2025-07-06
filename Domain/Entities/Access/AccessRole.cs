using Domain.Common;

namespace Domain.Entities.Access
{
    public class AccessRole : BaseEntity
    {
        // Propriedades do papel de acesso
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Construtor que inicializa o papel de acesso
        public AccessRole(string name, string description)
        {
            Name = name;
            Description = description;
            IsActive = true; // Define o papel como ativo por padrão
            Validate(); // Valida as propriedades do papel de acesso
        }

        // Método para validar as propriedades do papel de acesso
        public void Validate()
        {
            // Verifica se o nome é válido
            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                throw new ArgumentException("Name must be a non-empty string with a maximum length of 100 characters.", nameof(Name));
            if (Name.Length < 3)
                throw new ArgumentException("Name must be at least 3 characters long.", nameof(Name));

            // Verifica se a descrição é válida
            if (string.IsNullOrEmpty(Description) || Description.Length > 500)
                throw new ArgumentException("Description must be a non-empty string with a maximum length of 500 characters.", nameof(Description));
            if (Description.Length < 10)
                throw new ArgumentException("Description must be at least 10 characters long.", nameof(Description));
        }
    }
}
