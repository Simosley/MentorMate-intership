using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResturantApi.Business.Services;
using ResturantApi.Domain.Entities;
using ResturantApi.Domain.Models;
using static ResturantApi.Domain.Entities.Status;

namespace ResturantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> GetAllOrdersAsyncPaginatedAsync(string? username,int? tableId,Status? status,string? sortBy="Order Table Waiter Date",string? sortDirection="Desc or Asc", int page = 1, int pageSize = 20)
        {
            var userAuthenticated = User.Identity.Name;
            var roleAuthenticated = User.Claims.Where(x => x.Value == "Admin" || x.Value == "Waiter").Select(x => x.Value).FirstOrDefault();
            var getAllOrders= await _orderService.GetAllOrdersAsyncPaginatedAsync(userAuthenticated, roleAuthenticated,username, tableId,status, sortBy, sortDirection, page,pageSize);
            if (getAllOrders == null)
            {
                return BadRequest(Enumerable.Empty<Order>());
            }
            else
            {
                return Ok(getAllOrders);
            }
        }

        [HttpGet("{tableId}"),Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> GetOrderByTableIdAsync(int tableId)
        {
            var userAuthenticated = User.Identity.Name;
            var roleAuthenticated = User.Claims.Where(x => x.Value == "Admin" || x.Value == "Waiter").Select(x => x.Value).FirstOrDefault();
            var getOrderByTableId = await _orderService.GetOrderByTableIdAsync(tableId,userAuthenticated, roleAuthenticated);
            if (getOrderByTableId == null)
            {
                return BadRequest(Enumerable.Empty<Order>());
            }
            else
            {
                return Ok(getOrderByTableId);
            }
        }

        [HttpPost, Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> AddOrderAsync(OrderRequestModel orderRequestModel)
        {
            var userAuthenticated = User.Identity.Name;
            var addOrder = await _orderService.AddOrderAsync(orderRequestModel, userAuthenticated);
            if (addOrder == null)
            {
                return BadRequest("Couldnt create order,no product with that id or no table with that id");
            }
            else
            {
                return Ok(orderRequestModel);
            }
        }

        [HttpDelete("{id}"),Authorize(Roles ="Admin")]
        public async Task<ActionResult> DeleteOrderAsync(int id)
        {
            var deleteOrder = await _orderService.DeleteOrderAsync(id);
            if (deleteOrder == null)
            {
                return BadRequest("Couldnt delete order");
            }
            else
            {
                return Ok(deleteOrder);
            }
        }

        [HttpPut("{orderId} completed"), Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> UpdateOrderToCompletedAsync(int orderId)
        {
            var userAuthenticated = User.Identity.Name;
            var roleAuthenticated = User.Claims.Where(x => x.Value == "Admin" || x.Value == "Waiter").Select(x => x.Value).FirstOrDefault();

            var updateOrderToCompleted = await _orderService.UpdateOrderToCompletedAsync(orderId, userAuthenticated, roleAuthenticated);
            if (updateOrderToCompleted == null)
            {
                return BadRequest("Couldnt update order to completed");
            }
            else
            {
                return Ok("Order changed to completed");
            }
        }

        [HttpPut("{id}"),Authorize(Roles = "Admin,Waiter")]
        public async Task<ActionResult> UpdateOrderAsync(int id,OrderRequestModel orderRequestModel)
        {
            var userAuthenticated = User.Identity.Name;
            var roleAuthenticated = User.Claims.Where(x => x.Value == "Admin" || x.Value == "Waiter").Select(x => x.Value).FirstOrDefault();
            var updateOrder = await _orderService.UpdateOrderAsync(id, orderRequestModel,userAuthenticated,roleAuthenticated);
            if(updateOrder == null)
            {
                return BadRequest("Couldnt update order");
            }
            else
            {
                return Ok(orderRequestModel);
            }
        }
    }
}
