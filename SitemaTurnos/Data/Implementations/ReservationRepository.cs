using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;

namespace SitemaTurnos.Data.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        public static List<Reservation> reservations  = new List<Reservation>()
        {
            new Reservation
            {
                Id = 1,
                DateReservation = DateTime.Now.AddDays(1),
                NumOfPeople = 2,
                ReservStatus = Disponibility.Reservado,
                IdTable = 1,
                IdClient = 1
            },
            new Reservation
            {
                Id = 2,
                DateReservation = DateTime.Now.AddDays(2),
                NumOfPeople = 4,
                ReservStatus = Disponibility.Reservado,
                IdTable = 2,
                IdClient = 2
            },
            new Reservation
            {
                Id = 3,
                DateReservation = DateTime.Now.AddDays(3),
                NumOfPeople = 3,
                ReservStatus = Disponibility.Reservado,
                IdTable = 3,
                IdClient = 3
            },
            new Reservation
            {
                Id = 4,
                DateReservation = DateTime.Now.AddDays(4),
                NumOfPeople = 6,
                ReservStatus = Disponibility.Reservado,
                IdTable = 4,
                IdClient = 4
            },
        };

        public List<Reservation> GetAllReservations()
        {
            return reservations;
        }

        public Reservation GetReservationById(int idReservation)
        {
            Reservation reservation = reservations.Find(r => r.Id == idReservation);
            return reservation;
        }

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            Reservation reservaExistente = reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (reservaExistente != null)
            {
                reservaExistente.DateReservation = reservation.DateReservation;
                reservaExistente.NumOfPeople = reservation.NumOfPeople;
                reservaExistente.ReservStatus = reservation.ReservStatus;
                reservaExistente.IdTable = reservation.IdTable;
                reservaExistente.IdClient = reservation.IdClient;
            }
            return reservaExistente;
        }

        public Reservation DeleteReservation(int reservationId)
        {
            Reservation reservaABorrar = reservations.FirstOrDefault(r => r.Id == reservationId);
            if (reservaABorrar != null)
            {
                reservations.Remove(reservaABorrar);
            }

            return reservaABorrar;
        }
    }
}
