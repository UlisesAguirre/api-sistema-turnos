using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.Data.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        List<Reservation> GetReservationByTable(int id);
        Reservation AddReservation(Reservation reservation);
        Reservation UpdateReservation(Reservation reservation);
        Reservation DeleteReservation(int reservationId);
        List<Reservation> ReservationsForDate(DateTime date, Disponibility disponibility, string userRole);
    }
}
