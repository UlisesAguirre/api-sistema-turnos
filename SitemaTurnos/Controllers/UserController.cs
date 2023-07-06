using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;

namespace SitemaTurnos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService) //implementacion 
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public ActionResult<List<User>> GetUsers()
        {
            List<User> usuarios = _userService.GetUsers();

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet("{userId}", Name = "get")]
        public ActionResult<User> Get(int userId)
        {
            User usuario = _userService.Get(userId);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost("post")]

        public ActionResult<User> Post([FromBody] User user)
        {
            _userService.Post(user);
            return Ok();
        }



        [HttpPut("Put")]
        public ActionResult<User> Put([FromBody] User user)
        {
            User usuario = _userService.Put(user);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{userId}", Name = "DeleteUser")]
        public ActionResult<User> Delete(int userId) //Por que tipo <User> y no tipo <Int>
        {
            User usuarioABorrar = _userService.Delete(userId);
            if (usuarioABorrar == null)
            {
                return NotFound();
            }
            return Ok();
        }

        //CONSULTAR: que tantos endpoints con respecto a las reservaciones deberian ir aca?
        //Teniendo en cuenta que el usuario puede ver sus reservas, crearlas, modificarlas y eliminarlas.
        
        //[HttpGet("reservations")]
        //public ActionResult<ICollection<Reservation>> GetReservations()
        //{
        //    return Ok("Hola");
        //}
    }
}
