using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservations(int id);
        ReservationDto Post(ReservationDto reservation);
        ReservationDto Put(ReservationDto reservation);
        ReservationDto Delete(int reservationId);
    }
}
