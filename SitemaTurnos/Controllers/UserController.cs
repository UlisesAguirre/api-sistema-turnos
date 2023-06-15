using Microsoft.AspNetCore.Mvc;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

       public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return null;
        }

        //[HttpGet("reservations")]
        //public ActionResult<ICollection<Reservation>> GetReservations()
        //{
        //    return Ok("Hola");
        //}
    }
}
