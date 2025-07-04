
namespace Domain.Enums
{
    public enum ReservationStatus
    {
        Pending,    // Reservation is pending approval
        Approved,   // Reservation has been approved
        Rejected,   // Reservation has been rejected
        Cancelled,  // Reservation has been cancelled
        Completed   // Reservation has been completed
    }
}
