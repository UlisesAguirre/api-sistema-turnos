using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
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
        public ActionResult<List<UserDto>> GetUsers()
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            List<UserDto> usuarios = _userService.GetUsers();

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpGet("{userId}", Name = "get")]
        public ActionResult<UserDto> Get(int userId)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                UserDto usuario = _userService.Get(Int32.Parse(user));

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }

            UserDto adminUsuario = _userService.Get(userId);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok(adminUsuario);
        }

        [HttpPost("post")]

        public ActionResult<UserDto> Post([FromBody] UserDto user)
        {
            _userService.Post(user);
            return Ok();
        }



        [HttpPut("Put")]
        public ActionResult<UserDto> Put([FromBody] UserDto userModified)
        {

            var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                userModified.Id = Int32.Parse(userId);
                UserDto usuario = _userService.Put(userModified);

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok();
            }

            UserDto adminUsuario = _userService.Put(userModified);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{userId}", Name = "DeleteUser")]
        public ActionResult<UserDto> Delete(int userId)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
            {
                UserDto usuario = _userService.Delete(Int32.Parse(user));

                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok();
            }

            UserDto adminUsuario = _userService.Delete(userId);

            if (adminUsuario == null)
            {
                return NotFound();
            }
            return Ok();
            
        }

    }
}
