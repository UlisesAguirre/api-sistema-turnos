using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;
using SitemaTurnos.Services.Interfaces;
using System.Security.Claims;

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
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

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
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                User usuario = _userService.Get(int.Parse(user));

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }

            User adminUsuario = _userService.Get(userId);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok(adminUsuario);
        }

        [HttpPost("post")]

        public ActionResult<User> Post([FromBody] User user)
        {
            _userService.Post(user);
            return Ok();
        }



        [HttpPut("Put")]
        public ActionResult<User> Put([FromBody] User userModified)
        {

            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                User usuario = _userService.PutClient(int.Parse(user), userModified);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }

            User adminUsuario = _userService.Put(userModified);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok(adminUsuario);
        }

        [HttpDelete("{userId}", Name = "DeleteUser")]
        public ActionResult<User> Delete(int userId)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                User usuario = _userService.Delete(int.Parse(user));

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }

            User adminUsuario = _userService.Delete(userId);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok(adminUsuario);
            
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
