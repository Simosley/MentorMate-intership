using ResturantApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ResturantApi.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ResturantApiContext _context;
        public OrderRepository(ResturantApiContext context)
        {
            _context = context;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteOrderAsync(int id, Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            var getAllOrders = await _context.Orders.Include(x => x.Product).ToListAsync();
            return getAllOrders;
        }

        public async Task<List<Order>> GetAllOrdersAsyncPaginatedAsync(int page, int pageSize)
        {
            var getAllOrders = await _context.Orders.Skip((page - 1) * pageSize).Take(pageSize).Include(x => x.Product).ToListAsync();
            return getAllOrders;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var getOrderByid = await _context.Orders.FindAsync(id);
            return getOrderByid;
        }

        public async Task<List<Order>> GetOrderByTableIdAsync(int tableId)
        {
            var getOrderByTableId = await _context.Orders.Include(x => x.Product).Where(x => x.TableId == tableId).ToListAsync();
            return getOrderByTableId;
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
