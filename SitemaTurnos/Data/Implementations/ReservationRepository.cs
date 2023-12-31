﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SitemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
using System.Linq;

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

        public List<Reservation> GetReservationByTable(int id)
        {
            List<Reservation> reservaciones = _dbContext.Reservations.Include(u => u.User).Include(t => t.Table).Where(r => r.TableId == id).ToList();
            return reservaciones;
        }

        public Reservation AddReservation(Reservation reservation)
        {
            var user = _dbContext.Users.Find(reservation.UserId);
            var table = _dbContext.TablesRestaurant.Find(reservation.TableId);
            var reservationTurn = _dbContext.Reservations.FirstOrDefault(r => r.turn == reservation.turn && r.DateReservation == reservation.DateReservation && r.TableId == reservation.TableId && r.ReservStatus != Disponibility.Cancelado);
            
            if (user != null && table != null && reservationTurn == null)
            {
               _dbContext.Reservations.Add(reservation);

               _dbContext.SaveChanges();

                return reservation;

            }
            return null;
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            Reservation reservaExistente = _dbContext.Reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (reservaExistente == null)
            {
                return reservaExistente;
            }

            var user = _dbContext.Users.Find(reservation.UserId);
            var table = _dbContext.TablesRestaurant.Find(reservation.TableId);
            var reservationTurn = _dbContext.Reservations.FirstOrDefault(r => r.turn == reservation.turn && r.DateReservation == reservation.DateReservation && r.TableId == reservation.TableId);

            if (user != null && table != null && reservationTurn == null && reservaExistente.UserId == user.Id)
            {
                reservaExistente.DateReservation = reservation.DateReservation;
                reservaExistente.NumOfPeople = reservation.NumOfPeople;
                reservaExistente.ReservStatus = reservation.ReservStatus;
                reservaExistente.TableId = reservation.TableId;
                reservaExistente.UserId = reservation.UserId;

                _dbContext.SaveChanges();
            }
            return null;
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

        public List<Reservation> ReservationsForDate(DateTime date, Disponibility disponibility, string userRole)
        {
            if (userRole != "Admin")
            {
                List<Reservation> reservations = _dbContext.Reservations.Where(r => r.DateReservation == date && r.ReservStatus == Disponibility.Disponible).ToList();
                return reservations;
            }

            List<Reservation> totalReservations = _dbContext.Reservations.Where(r => r.DateReservation == date && r.ReservStatus == disponibility).ToList();
            return totalReservations;
        }
    }
}
