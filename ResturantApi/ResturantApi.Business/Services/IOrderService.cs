using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public interface IOrderService
    {
        Task<OrderResponseModel> GetAllOrdersAsyncPaginatedAsync(string userAuthenticated, string roleAuthenticated, string? username, int? tableId, Status? status, string? sortBy, string? sortDirection, int page, int pageSize);
        Task<OrderByIdResponseModel> GetOrderByTableIdAsync(int tableId, string userAuthenticated, string roleAuthenticated);
        Task<Order> AddOrderAsync(OrderRequestModel orderRequestModel, string userAuthenticated);
        Task<Order> DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(int id, OrderRequestModel orderRequestModel, string userAuthenticated, string roleAuthenticated);
        Task<Order> UpdateOrderToCompletedAsync(int orderId, string userAuthenticated, string roleAuthenticated);
    }
}
