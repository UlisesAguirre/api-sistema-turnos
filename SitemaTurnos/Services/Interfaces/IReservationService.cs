using RestaurantReservations.Models;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservations(int id);
        ReservationDto Post(ReservationDto reservation);
        ReservationDto Put(ReservationDto reservation);
        ReservationDto Delete(int reservationId);
        List<Reservation> ReservationsForDate(DateTime date, Disponibility disponibility, string userRole);
    }
}
