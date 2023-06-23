using Microsoft.AspNetCore.Mvc;
using SistemaTurnos.Services.Interfaces;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService) 
        {
            _tableService = tableService;
        }

        [HttpGet("GetTables")]
        public ActionResult<List<TableRestaurant>> GetTables()
        {
            List<TableRestaurant> mesas = _tableService.GetTables();

            if (mesas == null)
            {
                return NotFound();
            }
            return Ok(mesas);
        }

        [HttpGet("{tableId}", Name = "getTable")]
        public ActionResult<TableRestaurant> GetTable(int tableId)
        {
            TableRestaurant mesa = _tableService.Get(tableId);

            if (mesa == null)
            {
                return NotFound();
            }
            return Ok(mesa);
        }

        [HttpPost("post")]

        public ActionResult<TableRestaurant> Post([FromBody] TableRestaurant table)
        {
            _tableService.Post(table);
            return Ok();
        }



        [HttpPut("Put")]
        public ActionResult<TableRestaurant> Put([FromBody] TableRestaurant table)
        {
            TableRestaurant mesa = _tableService.Put(table);

            if (mesa == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{tableId}", Name = "DeleteTable")]
        public ActionResult<TableRestaurant> Delete(int tableId) 
        {
            TableRestaurant mesaABorrar = _tableService.Delete(tableId);
            if (mesaABorrar == null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
