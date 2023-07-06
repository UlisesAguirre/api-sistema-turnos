using Microsoft.EntityFrameworkCore;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.Data.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        readonly UserDbContext _dbContext;

        public ReservationRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservaciones = _dbContext.Reservations.ToList();
            return reservaciones;
        }

        public Reservation GetReservationById(int idReservation)
        {
            Reservation reservaciones = _dbContext.Reservations.Find(idReservation);
            return reservaciones;
        }

        public void AddReservation(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);

            _dbContext.SaveChanges();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            Reservation reservaExistente = _dbContext.Reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (reservaExistente != null)
            {
                reservaExistente.DateReservation = reservation.DateReservation;
                reservaExistente.NumOfPeople = reservation.NumOfPeople;
                reservaExistente.ReservStatus = reservation.ReservStatus;
                reservaExistente.IdTable = reservation.IdTable;
                reservaExistente.IdClient = reservation.IdClient;

                _dbContext.SaveChanges();
            }
            return reservaExistente;
        }

        public Reservation DeleteReservation(int reservationId)
        {
            Reservation reservaABorrar = _dbContext.Reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservaABorrar != null)
            {
                _dbContext.Reservations.Remove(reservaABorrar);

                _dbContext.SaveChanges();
            }

            return reservaABorrar;
        }
    }
}
