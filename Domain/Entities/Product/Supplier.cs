
using Domain.Common;

namespace Domain.Entities.Product
{
    public class Supplier : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public Supplier(string name, string code, string contactName, string email, string phone)
        {
            Validate(name, code, contactName, email, phone);
            Name = name;
            Code = code;
            ContactName = contactName;
            Email = email;
            Phone = phone;
            IsActive = true;
        }

        public void Validate(string name, string code, string contactName, string email, string phone)
        {
            ValidateString(name, 1, 200, nameof(Name), "Name must be between 1 and 200 characters.");
            ValidateString(code, 1, 50, nameof(Code), "Code must be between 1 and 50 characters.");
            ValidateString(contactName, 0, 100, nameof(ContactName), "Contact name must be between 0 and 100 characters.");
            // TODO[FEATURE]: Add email validation logic here, e.g., regex for email format.
            ValidateString(email, 1, 100, nameof(Email), "Email must be between 0 and 100 characters.");
            // TODO[FEATURE]: Add phone validation logic here, e.g., regex for phone format.
            ValidateString(phone, 1, 20, nameof(Phone), "Phone must be between 0 and 20 characters.");

        }
    }
}
