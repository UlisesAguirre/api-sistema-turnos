using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Implementations;
using SitemaTurnos.Services.Interfaces;

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
        public ActionResult<List<Reservation>> GetAll() 
        {
            List<Reservation> reservations = _reservationService.GetAllReservations();
            return Ok(reservations);
        }

        [HttpGet("{idReservation}", Name = "GetById")]
        public ActionResult<Reservation> GetById(int idReservation)
        {
            Reservation reservation = _reservationService.GetReservations(idReservation);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPost("Post")]
        public ActionResult<Reservation> Post(Reservation reservation)
        {
            _reservationService.Post(reservation);
            return Ok();
        }

        [HttpPut("Put")]
        public ActionResult<Reservation> Put([FromBody] Reservation reservation)
        {
            Reservation reserva = _reservationService.Put(reservation);

            if (reserva == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{reservationId}", Name = "DeleteReservation")]
        public ActionResult<Reservation> Delete(int reservationId) 
        {
            Reservation reservaABorrar = _reservationService.Delete(reservationId);
            if (reservaABorrar == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
