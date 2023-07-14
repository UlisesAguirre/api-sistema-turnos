using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Entities;
using System.Security.Claims;

namespace SistemaTurnos.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService) 
        {
            _tableService = tableService;
        }

        [HttpGet("GetTables")]
        public ActionResult<List<TableDto>> GetTables()
        {
            List<TableDto> tables = _tableService.GetTables();

            if (tables == null)
            {
                return NotFound();
            }
            return Ok(tables);
        }

        [HttpGet("{idTable}", Name = "getTable")]
        public ActionResult<TableDto> GetTable(int tableId)
        {
            TableDto table = _tableService.Get(tableId);

            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }

        [HttpPost("post")]

        public ActionResult<TableDto> Post([FromBody] TableDto table)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            _tableService.Post(table);
            return Ok();
        }



        [HttpPut("Put")]
        public ActionResult<TableDto> Put([FromBody] TableDto table)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            TableDto tableModified = _tableService.Put(table);

            if (tableModified == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{idTableToDelete}", Name = "DeleteTable")]
        public ActionResult<TableDto> Delete(int tableId) 
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            TableDto table = _tableService.Delete(tableId);
            if (table == null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
