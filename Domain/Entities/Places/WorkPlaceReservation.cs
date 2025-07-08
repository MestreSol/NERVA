using Domain.Common;
using Domain.Enums;

namespace Domain.Entities.Places
{
    public class WorkPlaceReservation : BaseAuditableEntity
    {
        public WorkPlace WorkPlace { get; set; }
        public Guid WorkPlaceId { get; set; }
        public Guid ReservedById { get; set; }
        public Employee.Employee ReservedBy { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Purpose { get; set; }

        public WorkPlaceReservation(WorkPlace workPlace, Employee.Employee reservedBy, DateTime reservedFrom, DateTime reservedTo, ReservationStatus purpose)
        {
            Validate(workPlace, reservedBy, reservedFrom, reservedTo);
            WorkPlace = workPlace;
            WorkPlaceId = workPlace.Id;
            ReservedBy = reservedBy;
            ReservedById = reservedBy.Id;
            ReservedFrom = reservedFrom;
            ReservedTo = reservedTo;
            ReservationDate = DateTime.UtcNow;
            Purpose = purpose;
        }

        public void Validate(WorkPlace workPlace, Employee.Employee reservedBy, DateTime reservedFrom, DateTime reservedTo)
        {
            ValidateObject(workPlace, nameof(WorkPlace), "Work place cannot be null.");
            ValidateObject(reservedBy, nameof(ReservedBy), "Reserved by cannot be null.");
            if (reservedFrom >= reservedTo)
            {
                throw new ArgumentException("Reserved from must be earlier than reserved to.", nameof(reservedFrom));
            }
            if (reservedFrom < DateTime.UtcNow)
            {
                throw new ArgumentException("Reserved from cannot be in the past.", nameof(reservedFrom));
            }
            
        }
    }
}
