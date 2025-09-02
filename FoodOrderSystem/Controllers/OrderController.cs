using FoodOrderSystem.Entities;
using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using Microsoft.AspNetCore.Mvc;
using OrderStatus = FoodOrderSystem.Entities.Enums.OrderStatus;

namespace FoodOrderSystem.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync([FromBody] AddOrderRequest request)
        {
            var orderId = await _orderService.AddOrderAsync(request.CustomerId, request.DeliveryDate, request.DeliveryAddress);

            foreach (var orderItem in request.OrderItems)
            {
                await _orderService.AddOrderItemAsync(orderId, orderItem.MenuId, orderItem.Quantity);
            }
            
            // Calculate Order Amount (order>Id)

            return Ok(orderId);
        }

        [HttpPost]
        [Route("{orderId}/order-items")]
        public async Task<IActionResult> AddOrderItemAsync(int orderId, [FromBody] AddOrderItem request)
        {
            var orderItemId = await _orderService.AddOrderItemAsync(orderId, request.MenuId, request.Quantity);
            return Ok(orderItemId);
        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderAsync([FromRoute] int orderId)
        {
            await _orderService.GetOrderAsync(orderId);
            return Ok(orderId);
        }

        [HttpPut]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateOrderAsync([FromRoute] int orderId, [FromBody] UpdateOrderRequest request)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            if (order == null)
            {
                return BadRequest($"Order not found with this id: {orderId}");
            }

            order = await _orderService.UpdateOrderAsync(orderId, request.DeliveryDate, request.DeliveryAddress);
            return Ok(order);
        }
        [HttpPut]
        [Route("{orderId}/OrderStatus/{orderStatus}")]
        public async Task<IActionResult> UpdateOrderStatusAsync(int orderId, string orderStatus)
        {
            if(Enum.TryParse(orderStatus, out OrderStatus status))
            {
                await _orderService.UpdateOrderStatusAsync(orderId, status);

                return Ok();
            }
            return BadRequest(status);

            
        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] int orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
            return Ok();
        }

        [HttpPut]
        [Route("{orderId}/order-items/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemAsync(int orderId, int orderItemId, [FromBody] UpdateOrderItemRequest request)
        {
            var updatedOrdItem = await _orderService.UpdateOrderItemAsync(orderId, orderItemId, request.Quantity);

            return Ok(updatedOrdItem);
        }
        [HttpDelete]
        [Route("{orderId}/order-items/{orderItemId}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int orderId, int orderItemId)
        {
            await _orderService.DeleteOrderItemAsync(orderId, orderItemId);
            return Ok();
        }


    }

}
