using Domain.Common;

namespace Domain.Entities.Places
{
    public class WorkPlaceReservation : BaseAuditableEntity
    {
        public WorkPlace WorkPlace { get; set; } = null!;
        public Guid WorkPlaceId { get; set; }
        public Guid ReservedById { get; set; }
        public Employee.Employee ReservedBy { get; set; } = null!;
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public ReservationStatus Purpose { get; set; } = ReservationStatus.Pending;

    }
}
