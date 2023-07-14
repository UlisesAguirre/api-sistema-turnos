using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
using SistemaTurnos.Enums;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
using SitemaTurnos.Services.Implementations;
using SitemaTurnos.Services.Interfaces;
using System.Security.Claims;

namespace SitemaTurnos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService) 
        {
            _reservationService = reservationService;
        }

        [HttpGet("GetReservations")]
        public ActionResult<List<Reservation>> GetAll() 
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            List<Reservation> reservations = _reservationService.GetAllReservations();

            return Ok(reservations);
        }

        [HttpGet("{idReservation}", Name = "GetById")]
        public ActionResult<Reservation> GetById(int idReservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            Reservation reservation = _reservationService.GetReservations(idReservation);
            if (reservation == null)
            {
                return NotFound();
            }

            if(userRole != "Admin" && reservation.UserId != Int32.Parse(user))
            {
                return Forbid();
            }

            return Ok(reservation);
        }

        [HttpPost("Post")]
        public ActionResult<ReservationDto> Post([FromBody] ReservationDto reservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            reservation.ReservStatus = Disponibility.Reservado;
            reservation.DateReservation = reservation.DateReservation.Date + TimeSpan.Zero;

            if (!Enum.IsDefined(typeof(Turns), reservation.turn) || !Enum.IsDefined(typeof(Disponibility), reservation.ReservStatus))
            {
                return BadRequest();
            }

            if (userRole != "Admin")
            {
                reservation.UserId = Int32.Parse(user);
            }
             ReservationDto newReservation = _reservationService.Post(reservation);

            if (newReservation != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("Put")]
        public ActionResult<ReservationDto> Put([FromBody] ReservationDto reservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;


            reservation.DateReservation = reservation.DateReservation.Date + TimeSpan.Zero;

            if (!Enum.IsDefined(typeof(Turns), reservation.turn) || !Enum.IsDefined(typeof(Disponibility), reservation.ReservStatus))
            {
                return BadRequest();
            }

            if (userRole != "Admin")
            {
                reservation.UserId = Int32.Parse(user);
            }

            ReservationDto reservationModified = _reservationService.Put(reservation);

            if (reservationModified == null)
            {
                return NotFound();
            }

            return Ok();
            
        }

        [HttpDelete("{idReservationToDelete}", Name = "DeleteReservation")]
        public ActionResult<ReservationDto> Delete(int reservationId) 
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            ReservationDto reservation = _reservationService.Delete(reservationId);

            if (userRole != "Admin")
            {
                return Forbid();
            }

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("ReservationsForDate")]

        public ActionResult<List<Reservation>> GetReservationsForDate([FromQuery] DateTime date, [FromQuery] Disponibility disponibility)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            date = date.Date + TimeSpan.Zero;


            return _reservationService.ReservationsForDate(date, disponibility, userRole);

        }
    }
}
