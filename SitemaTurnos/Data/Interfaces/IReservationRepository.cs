using SitemaTurnos.Entities;

namespace SitemaTurnos.Data.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        void AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservation(int reservationId);
    }
}
