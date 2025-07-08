
using Domain.Common;

namespace Domain.Entities.Employee
{
    public class Departament : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Departament(string name, string abreviation, string description)
        {
            Validate(name, abreviation, description);
            Name = name;
            Abreviation = abreviation;
            Description = description;
            IsActive = true;
        }

        public void Validate(string name, string abreviation, string description)
        {
            ValidateString(name, 1, 200, nameof(name), "Name must be between 1 and 200 characters.");
            ValidateString(abreviation, 1, 10, nameof(abreviation), "Abreviation must be between 1 and 10 characters.");
            ValidateString(description, 0, 1000, nameof(description), "Description must be up to 1000 characters long.");
        }
    }
}
