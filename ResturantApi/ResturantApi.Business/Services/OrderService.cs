using ResturantApi.Data.Repositories;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;
using static ResturantApi.Domain.Entities.Status;

namespace ResturantApi.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository,IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<Order> AddOrderAsync(OrderRequestModel orderRequestModel, string userAuthenticated)
        {
            if (orderRequestModel.TableId < 1 || orderRequestModel.TableId > 10) return null;
            var checkProductId = await _productRepository.GetProductByIdAsync(orderRequestModel.ProductId);
            if (checkProductId == null) return null;
            var order = new Order
            {
                TableId = orderRequestModel.TableId,
                ProductId = orderRequestModel.ProductId,
                Quantity = orderRequestModel.Quantity,
                Username = userAuthenticated,
                CreatedAt = DateTime.Now
            };
            var addOrder = await _orderRepository.AddOrderAsync(order);

            return addOrder;
        }

        public async Task<Order> DeleteOrderAsync(int id)
        {
            var targetOrder = await _orderRepository.GetOrderByIdAsync(id);
            if (targetOrder == null) return null;

            return await _orderRepository.DeleteOrderAsync(id, targetOrder);
        }

        public async Task<OrderResponseModel> GetAllOrdersAsyncPaginatedAsync(string userAuthenticated, string roleAuthenticated, string? username, int? tableId, Status? status, string? sortBy, string? sortDirection, int page, int pageSize)
        {
            var getAllOrders = await _orderRepository.GetAllOrdersAsyncPaginatedAsync(page, pageSize);
            var items = new List<OrderResponseModelItems>();
            if (roleAuthenticated == "Waiter")
            {
                items = getAllOrders.
                    Where(x => x.Username == userAuthenticated).ToList().
                    Select(x => new OrderResponseModelItems
                    {
                        OrderId = x.OrderId,
                        TableId = (int)x.TableId,
                        ProductId = (int)x.ProductId,
                        TotalPrice = (decimal)x.Quantity * x.Product.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        Username = x.Username
                    }).ToList();
            }
            if (roleAuthenticated == "Admin")
            {
                if (username != null)
                {
                    items = getAllOrders.
                        Where(x => x.Username == username).
                        Select(x => new OrderResponseModelItems
                        {
                            OrderId = x.OrderId,
                            TableId = (int)x.TableId,
                            ProductId = (int)x.ProductId,
                            TotalPrice = (decimal)x.Quantity * x.Product.Price,
                            Status = x.Status,
                            CreatedAt = x.CreatedAt,
                            Username = x.Username
                        }).ToList();
                }
                else
                {
                    items = getAllOrders.
                        Select(x => new OrderResponseModelItems
                        {
                            OrderId = x.OrderId,
                            TableId = (int)x.TableId,
                            ProductId = (int)x.ProductId,
                            TotalPrice = (decimal)x.Quantity * x.Product.Price,
                            Status = x.Status,
                            CreatedAt = x.CreatedAt,
                            Username = x.Username
                        }).ToList();
                }
            }
            if (tableId != null)
            {
                items = getAllOrders.
                    Where(x => x.TableId == tableId).
                    Select(x => new OrderResponseModelItems
                    {
                        OrderId = x.OrderId,
                        TableId = (int)x.TableId,
                        ProductId = (int)x.ProductId,
                        TotalPrice = (decimal)x.Quantity * x.Product.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        Username = x.Username
                    }).ToList();
            }
            if (status != null)
            {
                items = getAllOrders.
                    Where(x => x.Status == status).
                    Select(x => new OrderResponseModelItems
                    {
                        OrderId = x.OrderId,
                        TableId = (int)x.TableId,
                        ProductId = (int)x.ProductId,
                        TotalPrice = (decimal)x.Quantity * x.Product.Price,
                        Status = x.Status,
                        CreatedAt = x.CreatedAt,
                        Username = x.Username
                    }).ToList();
            };
            if (sortBy == "Order")
            {
                items = items.OrderBy(x => x.OrderId).ToList();
                if (sortDirection == "Desc") items = items.OrderByDescending(x => x.OrderId).ToList();
            };
            if (sortBy == "Table")
            {
                items = items.OrderBy(x => x.TableId).ToList();
                if (sortDirection == "Desc") items = items.OrderByDescending(x => x.TableId).ToList();
            };
            if (sortBy == "Waiter")
            {
                items = items.OrderBy(x => x.Username).ToList();
                if (sortDirection == "Desc") items = items.OrderByDescending(x => x.Username).ToList();
            };
            if (sortBy == "Date")
            {
                items = items.OrderBy(x => x.CreatedAt).ToList();
                if (sortDirection == "Desc") items = items.OrderByDescending(x => x.CreatedAt).ToList();
            };
            var response = new OrderResponseModel
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalOrders = items.Count,
                Items = items
            };

            return response;
        }

        public async Task<OrderByIdResponseModel> GetOrderByTableIdAsync(int tableId, string userAuthenticated, string roleAuthenticated)
        {
            var getOrderByTableId = await _orderRepository.GetOrderByTableIdAsync(tableId);
            var items = new List<OrderByIdResponseModelProps>();
            if (roleAuthenticated == "Waiter")
            {
                items = getOrderByTableId.
                    Where(x => x.Status == Status.Completed && x.Username == userAuthenticated).
                    Select(x => new OrderByIdResponseModelProps
                    {
                        ProductId = (int)x.ProductId,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        Price = x.Product.Price
                    }).ToList();
            }
            if (roleAuthenticated == "Admin")
            {
                items = getOrderByTableId.
                    Where(x => x.Status == Status.Completed).
                    Select(x => new OrderByIdResponseModelProps
                    {
                        ProductId = (int)x.ProductId,
                        ProductName = x.Product.ProductName,
                        Quantity = x.Quantity,
                        Price = x.Product.Price
                    }).ToList();
            }
            var response = new OrderByIdResponseModel
            {
                TableId = tableId,
                Username = getOrderByTableId.Select(x => x.Username).FirstOrDefault(),
                Status = getOrderByTableId.Select(x => x.Status).FirstOrDefault(),
                TotalPrice = items.Sum(x => x.Quantity * x.Price),
                Products = items
            };

            return response;
        }

        public async Task<Order> UpdateOrderAsync(int id, OrderRequestModel orderRequestModel, string userAuthenticated, string roleAuthenticated)
        {
            if (orderRequestModel.TableId < 1 || orderRequestModel.TableId > 10) return null;
            var checkProductId = await _productRepository.GetProductByIdAsync(orderRequestModel.ProductId);
            if (checkProductId == null) return null;
            var getOrderById = await _orderRepository.GetOrderByIdAsync(id);
            if (getOrderById == null) return null;
            if (roleAuthenticated == "Waiter")
            {
                if (userAuthenticated == getOrderById.Username)
                {
                    getOrderById.TableId = orderRequestModel.TableId;
                    getOrderById.ProductId = orderRequestModel.ProductId;
                    getOrderById.Quantity = orderRequestModel.Quantity;
                }
                else return null;
            };
            if (roleAuthenticated == "Admin")
            {
                getOrderById.TableId = orderRequestModel.TableId;
                getOrderById.ProductId = orderRequestModel.ProductId;
                getOrderById.Quantity = orderRequestModel.Quantity;
            };

            return await _orderRepository.UpdateOrderAsync(id, getOrderById);
        }

        public async Task<Order> UpdateOrderToCompletedAsync(int orderId, string userAuthenticated, string roleAuthenticated)
        {
            var getOrderById = await _orderRepository.GetOrderByIdAsync(orderId);
            if (getOrderById == null) return null;
            if (roleAuthenticated == "Waiter")
            {
                if (userAuthenticated == getOrderById.Username)
                {
                    getOrderById.Status = Status.Completed;
                }
                else return null;
            }
            if (roleAuthenticated == "Admin") getOrderById.Status = Status.Completed;

            return await _orderRepository.UpdateOrderAsync(orderId, getOrderById);
        }
    }
}
