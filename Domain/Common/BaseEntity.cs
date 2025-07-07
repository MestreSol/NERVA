using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private readonly List<BaseEvent> _domainEvents = new();

        [NotMapped]
        public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(BaseEvent domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        public static void ValidateString(string value, int? minLenght, int maxLength, string? paramName, string? customMessaage)
        {
            if (value == null)
                throw new ArgumentNullException(paramName, customMessaage ?? $"{paramName} cannot be null.");
            if (value.Length > maxLength)
                throw new ArgumentException(customMessaage ?? $"{paramName} cannot exceed {maxLength} characters.", paramName);
            if (minLenght.HasValue && value.Length < minLenght.Value)
                throw new ArgumentException(customMessaage ?? $"{paramName} must be at least {minLenght.Value} characters long.", paramName);
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(customMessaage ?? $"{paramName} cannot be empty or whitespace.", paramName);
        }

        public static void ValidateList<T>(List<T> list, string paramName)
        {
            if (list == null)
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");
            if (list.Count == 0)
                throw new ArgumentException($"{paramName} cannot be empty.", paramName);
            if (list.Any(item => item == null))
                throw new ArgumentException("All items in the list must be non-null.", paramName);
        }

        public static void ValidateGuid(Guid guid, string paramName, string? customMessage = null)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException(customMessage ?? $"{paramName} must be a valid GUID.", paramName);
        }
        public static void ValidateObject(object obj, string paramName, string? customMessage = null)
        {
            if (obj == null)
                throw new ArgumentNullException(paramName, customMessage ?? $"{paramName} cannot be null.");
        }
}
