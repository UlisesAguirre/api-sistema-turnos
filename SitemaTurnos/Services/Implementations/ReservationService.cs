using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository) 
        {
            _reservationRepository = reservationRepository;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = _reservationRepository.GetAllReservations();
            return reservations;
        }

        public Reservation GetReservations(int idReservation)
        {
            Reservation reservation = _reservationRepository.GetReservationById(idReservation);
            return reservation;
        }

        public void Post(Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }


        public Reservation Put(Reservation reservation)
        {
            Reservation reserva = _reservationRepository.UpdateReservation(reservation);
            return reserva;
        }

        public Reservation Delete(int reservationId)
        {
            Reservation reservaABorrar = _reservationRepository.DeleteReservation(reservationId);
            return reservaABorrar;
        }
    }
}
