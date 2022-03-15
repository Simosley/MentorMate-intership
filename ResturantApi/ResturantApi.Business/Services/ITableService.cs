using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface ITableService
    {
        Task<List<TableResponseModel>> GetAllTablesAsync();
        Task<TableByIdResponseModel> GetTableByIdAsync(int tableId);
    }
}
