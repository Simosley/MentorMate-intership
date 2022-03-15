using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public interface ITableRepository
    {
        Task<List<Table>> GetAllTablesAsync();
        Task<Table> GetTableByIdAsync(int tableId);
    }
}
