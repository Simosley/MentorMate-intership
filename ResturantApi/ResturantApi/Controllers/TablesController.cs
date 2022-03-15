using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Entities;

namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly ITableService _tableService;
        public TablesController(ITableService tableService)
        {
            _tableService = tableService;
        }
        [HttpGet, Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> GetAllTablesAsync()
        {
            var allTables = await _tableService.GetAllTablesAsync();
            if (allTables == null)
            {
                return BadRequest(Enumerable.Empty<Table>());
            }
            return Ok(allTables);
        }

        [HttpGet("{tableId}"), Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> GetTableByIdAsync(int tableId)
        {
            var allTables = await _tableService.GetTableByIdAsync(tableId);
            if (allTables == null)
            {
                return BadRequest(Enumerable.Empty<Table>());
            }
            return Ok(allTables);
        }
    }
}
