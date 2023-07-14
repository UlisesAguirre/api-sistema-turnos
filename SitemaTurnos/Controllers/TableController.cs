using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservations.Models;
using SistemaTurnos.Enums;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Entities;
using SitemaTurnos.Enums;
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

        [HttpGet("{tableId}", Name = "getTable")]
        public ActionResult<TableDto> GetTable([FromRoute]int tableId)
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
        public ActionResult<TableDto> Delete([FromRoute] int idTableToDelete) 
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            if (userRole != "Admin")
                return Forbid();

            TableDto table = _tableService.Delete(idTableToDelete);
            if (table == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpGet("TablesForDate")]
        public ActionResult<List<TableDto>> GetTablesForDate([FromQuery] DateTime date, [FromQuery] Disponibility disponibility, [FromQuery]Turns turn)
        {
            var user = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            date = date.Date + TimeSpan.Zero;

            List<TableDto> tables = _tableService.TablesForDate(date, disponibility, turn, userRole);

            if(!tables.Any())
            {
                return NotFound();
            }

            return Ok(tables);

        }
    }
}
