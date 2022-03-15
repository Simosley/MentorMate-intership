using Microsoft.EntityFrameworkCore;
using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ResturantApiContext _context;
        public TableRepository(ResturantApiContext context)
        {
            _context = context;
        }
        public async Task<List<Table>> GetAllTablesAsync()
        {
            var getAllTables = await _context.Tables.ToListAsync();
            return getAllTables;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var getTableById = await _context.Tables.FindAsync(tableId);
            return getTableById;
        }
    }
}
