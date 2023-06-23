using SitemaTurnos.Entities;

namespace SitemaTurnos.Services.Interfaces
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetReservations(int id);
        void Post(Reservation reservation);
        Reservation Put(Reservation reservation);
        Reservation Delete(int reservationId);
    }
}
