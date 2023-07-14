using AutoMapper;
using RestaurantReservations.Models;
using SistemaTurnos.Data.Interfaces;
using SistemaTurnos.Enums;
using SitemaTurnos.Data.Implementations;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITableRepository _tableRepository;
        public ReservationService(IMapper mapper, IReservationRepository reservationRepository, IUserRepository userRepository, ITableRepository tableRepository) 
        {

            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _tableRepository = tableRepository;
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAllReservations();
        }

        public Reservation GetReservations(int idReservation)
        {
            return _reservationRepository.GetReservationById(idReservation);
        }

        public ReservationDto Post(ReservationDto reservation) 
        {

            reservation.User = _userRepository.GetById(reservation.UserId);
            reservation.Table = _tableRepository.GetById(reservation.TableId);


            Reservation Reservation = _mapper.Map<Reservation>(reservation);
            Reservation newReservation = _reservationRepository.AddReservation(Reservation);

            return _mapper.Map<ReservationDto>(newReservation);

        }

        public ReservationDto Put(ReservationDto reservation)
        {

            reservation.User = _userRepository.GetById(reservation.UserId);
            reservation.Table = _tableRepository.GetById(reservation.TableId);

            Reservation reserva = _mapper.Map<Reservation>(reservation);
            Reservation reservationModified = _reservationRepository.UpdateReservation(reserva);

            return _mapper.Map<ReservationDto>(reservationModified);
        }

        public ReservationDto Delete(int reservationId)
        {
            Reservation reservationDeleted = _reservationRepository.DeleteReservation(reservationId);
            return _mapper.Map<ReservationDto>(reservationDeleted);
        }

        public List<Reservation> ReservationsForDate(DateTime date, Disponibility disponibility, string userRole)
        {
            List<Reservation> reservations = _reservationRepository.ReservationsForDate(date, disponibility, userRole);

            foreach (Reservation reservation in reservations)
            {
                reservation.User = _userRepository.GetById(reservation.UserId);
                reservation.Table = _tableRepository.GetById(reservation.TableId);
            }

            return reservations;
        }
    }
}
