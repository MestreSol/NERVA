using Domain.Common;

namespace Domain.Entities.Employee
{
    public class Sector : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Sector(string name, string description)
        {
            Validate(name, description);
            Name = name;
            Description = description;
            IsActive = true;
        }

        public void Validate(string name, string description)
        {
            ValidateString(name, 1, 200, nameof(name), "Name is invalid");
            ValidateString(description, 0, 500, nameof(description), "Description is invalid");
        }
    }
}
