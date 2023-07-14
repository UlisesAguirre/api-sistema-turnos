using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            List<Reservation> reservaciones = _dbContext.Reservations.Include(u => u.User).Include(t => t.Table).ToList();
            return reservaciones;
        }

        public Reservation GetReservationById(int idReservation)
        {
            Reservation reservaciones = _dbContext.Reservations.Include(u => u.User).Include(t => t.Table).FirstOrDefault(u => u.Id == idReservation);
            return reservaciones;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            var user = _dbContext.Users.Find(reservation.UserId);
            var table = _dbContext.TablesRestaurant.Find(reservation.TableId);
            var reservationTurn = _dbContext.Reservations.FirstOrDefault(r => r.turn == reservation.turn && r.DateReservation == reservation.DateReservation);
            
            if (user  != null && table != null)
            {
                if ( reservationTurn == null)
                {
                    _dbContext.Reservations.Add(reservation);

                    _dbContext.SaveChanges();

                    return reservation;
                }
            }
            return null;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            Reservation reservaExistente = _dbContext.Reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (reservaExistente != null)
            {
                reservaExistente.DateReservation = reservation.DateReservation;
                reservaExistente.NumOfPeople = reservation.NumOfPeople;
                reservaExistente.ReservStatus = reservation.ReservStatus;
                reservaExistente.TableId = reservation.TableId;
                reservaExistente.UserId = reservation.UserId;

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
