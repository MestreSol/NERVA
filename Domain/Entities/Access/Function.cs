using Domain.Common;

namespace Domain.Entities.Access
{
    public class Function : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Function(string name, string description)
        {
            Name = name;
            Description = description;
            Validate(); 
        }

        public void Validate()
        {
            ValidateString(Name, 1, 100, nameof(Name), "Name must be a non-empty string with a maximum length of 100 characters.");
            ValidateString(Description, 1, 500, nameof(Description), "Description must be a non-empty string with a maximum length of 500 characters.");
        }
    }
}
