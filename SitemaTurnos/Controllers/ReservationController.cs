using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
using SitemaTurnos.Entities;
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

        [HttpGet("GetAll")]
        public ActionResult<List<ReservationDto>> GetAll() 
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            List<ReservationDto> reservations = _reservationService.GetAllReservations();

            return Ok(reservations);
        }

        [HttpGet("{idReservation}", Name = "GetById")]
        public ActionResult<ReservationDto> GetById(int idReservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            ReservationDto reservation = _reservationService.GetReservations(idReservation);
            if (reservation == null)
            {
                return NotFound();
            }

            if(userRole != "Admin" && reservation.IdClient != Int32.Parse(user))
            {
                return Forbid();
            }

            return Ok(reservation);
        }

        [HttpPost("Post")]
        public ActionResult<ReservationDto> Post(ReservationDto reservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                reservation.IdClient = Int32.Parse(user);
            }
            _reservationService.Post(reservation);

            return Ok();
        }

        [HttpPut("Put")]
        public ActionResult<ReservationDto> Put([FromBody] ReservationDto reservation)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            
            ReservationDto reservationModified = _reservationService.Put(reservation);

            if (reservationModified == null)
            {
                return NotFound();
            }

            if (userRole != "Admin" && reservationModified.IdClient != Int32.Parse(user))
            {
                return Forbid();
            }

            return Ok();
            
        }

        [HttpDelete("{reservationId}", Name = "DeleteReservation")]
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
    }
}
