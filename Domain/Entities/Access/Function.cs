using Domain.Common;

namespace Domain.Entities.Access
{
    public class Function : BaseAuditableEntity
    {
        // Propriedades da função
        public string Name { get; set; }
        public string Description { get; set; }

        // Construtor que inicializa as propriedades e valida os dados
        public Function(string name, string description)
        {
            Name = name;
            Description = description;
            Validate(); // Renomeado para um verbo mais claro
        }

        // Método para validar as propriedades da função
        public void Validate()
        {
            // Valida o nome
            if (string.IsNullOrEmpty(Name) || Name.Length > 100)
                throw new ArgumentException("Name must be a non-empty string with a maximum length of 100 characters.", nameof(Name));

            // Valida a descrição
            if (string.IsNullOrEmpty(Description) || Description.Length > 500)
                throw new ArgumentException("Description must be a non-empty string with a maximum length of 500 characters.", nameof(Description));
        }
    }
}
