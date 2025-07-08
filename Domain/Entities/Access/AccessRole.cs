using Domain.Common;

namespace Domain.Entities.Access
{
    public class AccessRole : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public AccessRole(string name, string description)
        {
            Validate(name, description);
            Name = name;
            Description = description;
            IsActive = true;
        }

        public void Validate(string Name, string Description)
        {
            ValidateString(Name, 1, 100, nameof(Name), "Name must be a non-empty string with a maximum length of 100 characters.");
            ValidateString(Description, 10, 500, nameof(Description), "Description must be a non-empty string with a maximum length of 500 characters.");
        }
    }
}
