using AutoMapper;
using RestaurantReservations.Models;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper) 
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public List<ReservationDto> GetAllReservations()
        {
            List<Reservation> reservations = _reservationRepository.GetAllReservations();
            return _mapper.Map<List<ReservationDto>>(reservations);
        }

        public ReservationDto GetReservations(int idReservation)
        {
            Reservation reservation = _reservationRepository.GetReservationById(idReservation);
            return _mapper.Map<ReservationDto>(reservation);
        }

        public void Post(ReservationDto reservation)
        {
            Reservation newReservation = _mapper.Map<Reservation>(reservation);
            _reservationRepository.AddReservation(newReservation);
        }

        public ReservationDto Put(ReservationDto reservation)
        {
            Reservation reserva = _mapper.Map<Reservation>(reservation);
            Reservation reservationModified = _reservationRepository.UpdateReservation(reserva);

            return _mapper.Map<ReservationDto>(reservationModified);
        }

        public ReservationDto Delete(int reservationId)
        {
            Reservation reservationDeleted = _reservationRepository.DeleteReservation(reservationId);
            return _mapper.Map<ReservationDto>(reservationDeleted);
        }
    }
}
