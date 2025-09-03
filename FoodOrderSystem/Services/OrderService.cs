using FoodOrderSystem.Entities;
using FoodOrderSystem.Orders;

using FoodOrderSystem.Repositories;
using OrderStatus = FoodOrderSystem.Entities.Enums.OrderStatus;

namespace FoodOrderSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuRepository _menuRepository;

        public OrderService(IOrderRepository orderRepository, IMenuRepository menuRepository)
        {
            _orderRepository = orderRepository;
            _menuRepository = menuRepository;
        }
        public async Task<int> AddOrderAsync(int customerID, DateTime deliveryDate, string deliveryAddress, decimal serviceFee = 0)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderStatusId = 1,
                CustomerId = customerID,
                DeliveryDate = deliveryDate,
                DeliveryAddress = deliveryAddress,
                ServiceFee = serviceFee,

            };
            await _orderRepository.AddOrderAsync(order);
            return order.Id;
        }



        public async Task<int> AddOrderItemAsync(int orderId, int menuId, int quantity)
        {
            // Get Menu using menuId
            var menu = await _menuRepository.GetMenuAsync(menuId) ?? throw new Exception($"Menu not found with this id: {menuId}");

            var orderItem = new OrderItem
            {
                OrderId = orderId,
                MenuId = menuId,
                Quantity = quantity,
                MenuPrice = menu.MenuPrice//use menu price from menu object
            };
            await CalculateTotalOrderPriceAsync(orderId);
            //use menu price from menu object

            await _orderRepository.AddOrderItemAsync(orderItem);

            return orderItem.Id;
        }

        public async Task CalculateTotalOrderPriceAsync(int orderId)
        {
            var order = await GetOrderAsync(orderId) ?? throw new Exception($" Order not found with this id: {orderId}");
            if (order != null && order.OrderItems.Count > 0)
            {
                order.TotalPrice = order.OrderItems.Sum(o => o.MenuPrice * o.Quantity);
            }

            await _orderRepository.UpdateOrderAsync(order);
        }
        public async Task<OrderItem> GetOrderItemAsync(int orderId, int orderItemId)
        {
            var ordItem = await _orderRepository.GetOrderItemAsync(orderItemId) ?? throw new Exception($"OrderItem not found with this id:{orderItemId}");
            return ordItem;

        }

        public async Task<OrderItem> UpdateOrderItemAsync(int orderID, int orderItemId, int quantity)
        {
            var ordItem = await _orderRepository.GetOrderItemAsync(orderItemId) ?? throw new Exception($"OrderItem not found with this id: {orderItemId}");
            ordItem.Quantity = quantity;
            await CalculateTotalOrderPriceAsync(orderID);

            await _orderRepository.UpdateOrderItemAsync(ordItem);
            return ordItem;
        }

        public async Task<Order> CancelOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id) ?? throw new Exception($" Order not found with this id: {id}");

            if (order.OrderStatusId == 5)
            {
                Console.WriteLine($"This order can not be cancelled : {id}");
            }
            order.OrderStatusId = 3;
            return order;
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id) ?? throw new Exception($" Order not found with this id: {id}");
            return order;

        }
        public async Task DeleteOrderItemAsync(int orderId, int orderItemId)
        {
            await _orderRepository.GetOrderItemAsync(orderItemId);
            await _orderRepository.DeleteOrderItemAsync(orderId, orderItemId);
            await CalculateTotalOrderPriceAsync(orderId);
        }

        public async Task<Order> UpdateOrderAsync(int orderId, DateTime deliveryDate, string deliveryAddress)
        {
            var order = await _orderRepository.GetOrderAsync(orderId) ?? throw new Exception($"Order not found with this id: {orderId}");
            order.DeliveryDate = deliveryDate;
            order.DeliveryAddress = deliveryAddress;
            await CalculateTotalOrderPriceAsync(orderId);
            await _orderRepository.UpdateOrderAsync(order);
            return order;
        }
        public async Task DeleteOrderAsync(int orderId)
        {
            var ord = await _orderRepository.GetOrderAsync(orderId) ?? throw new Exception($"Order not found with this id: {orderId}");
            await _orderRepository.DeleteOrderAsync(ord);
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.GetOrderAsync(orderId) ?? throw new Exception($"Order not found with this id: {orderId}");

            if (order.OrderStatusId == (int)orderStatus)
                return;


            if (
                (order.OrderStatusId == (int)(OrderStatus.Created) && (orderStatus == OrderStatus.Accepted || orderStatus == OrderStatus.Canceled)) ||
                (order.OrderStatusId == (int)(OrderStatus.Accepted) && (orderStatus == OrderStatus.Canceled || orderStatus == OrderStatus.Paid)) ||
                (order.OrderStatusId == (int)(OrderStatus.Paid) && (orderStatus == OrderStatus.Canceled || orderStatus == OrderStatus.Delivered))
               )
            {
                order.OrderStatusId = (int)orderStatus;
                await _orderRepository.UpdateOrderAsync(order);
                return;
            }
            else
            {
                throw new Exception($"This order status can not be changed: {orderId}");

            }




        }
    }
}
