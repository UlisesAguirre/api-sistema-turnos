using RestaurantReservations.Models;
using SitemaTurnos.Entities;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IReservationService
    {
        List<ReservationDto> GetAllReservations();
        ReservationDto GetReservations(int id);
        void Post(ReservationDto reservation);
        ReservationDto Put(ReservationDto reservation);
        ReservationDto Delete(int reservationId);
    }
}
