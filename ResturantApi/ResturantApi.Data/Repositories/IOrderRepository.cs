using ResturantApi.Domain.Entities;

namespace ResturantApi.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsyncPaginatedAsync(int page, int PageSize);
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> AddOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int id, Order order);
        Task<List<Order>> GetOrderByTableIdAsync(int tableId);
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order order);

    }
}
