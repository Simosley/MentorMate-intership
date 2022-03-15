using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;

namespace ResturantApi.Business.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IOrderRepository _orderRepository;
        public TableService(ITableRepository tableRepository, IOrderRepository orderRepository)
        {
            _tableRepository = tableRepository;
            _orderRepository = orderRepository;
        }
        public async Task<List<TableResponseModel>> GetAllTablesAsync()
        {
            var getAllTables = await _tableRepository.GetAllTablesAsync();
            var getAllOrders = await _orderRepository.GetAllOrdersAsync();
            var listOfTableIds = getAllOrders.Select(x => x.TableId).ToList();

            var tables = getAllTables.
            Select(x =>
            new TableResponseModel
            {
                TableId = x.TableId,
                TableNumber = x.TableNumber,
                TableStatus = getAllTables.Where(y => listOfTableIds.Contains(x.TableId)).Select(x => x.TableStatus = TableStatus.Active).FirstOrDefault(),
                Capacity = x.Capacity,
                Username = getAllOrders.Where(y => y.TableId == x.TableId).Select(x => x.Username).FirstOrDefault(),
                TotalPrice = getAllOrders.Sum(order => order.TableId == x.TableId ? order.Quantity * order.Product.Price : 0)
            }).ToList();

            return tables;
        }

        public async Task<TableByIdResponseModel> GetTableByIdAsync(int tableId)
        {
            var getTableById = await _tableRepository.GetTableByIdAsync(tableId);
            var allOrders = await _orderRepository.GetAllOrdersAsync();
            var order = new List<TableByIdResponseModelOrder>();
            var products = new List<TableByIdResponseModelProducts>();
            //TODO
            //It is working, but not properly
            order = allOrders.Where(x => x.TableId == tableId).
                Select(x => new TableByIdResponseModelOrder
                {
                    OrderId = x.OrderId,
                    Username = x.Username,
                    Status = x.Status,
                    TotalPrice = x.Quantity * x.Product.Price,
                    Products = products = allOrders.
                    Where(c => c.TableId == tableId).
                    Select(z => new TableByIdResponseModelProducts
                    {
                        ProductId = (int)x.ProductId,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        Price = x.Product.Price
                    }).ToList()
                }).ToList();

            var response = new TableByIdResponseModel
            {
                TableId = getTableById.TableId,
                TableNumber = getTableById.TableNumber,
                TableStatus = getTableById.TableStatus,
                Capacity = getTableById.Capacity,
                Order = order
            };

            return response;
        }
    }
}
