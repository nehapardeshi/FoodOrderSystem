using FoodOrderSystem.Entities;
using FoodOrderSystem.Orders;
using OrderStatus = FoodOrderSystem.Entities.Enums.OrderStatus;

namespace FoodOrderSystem.Services
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(int customerID, DateTime deliveryDate, string deliveryAddress, decimal serviceFee = 0);
        Task<int> AddOrderItemAsync(int orderId, int menuId, int quantity);
        Task<OrderItem> GetOrderItemAsync(int orderId, int orderItemId);
        Task<OrderItem> UpdateOrderItemAsync(int orderID, int orderItemId, int quantity);
        Task<Order> GetOrderAsync(int id);
        Task<Order> UpdateOrderAsync(int orderId, DateTime deliveryDate, string deliveryAddress);
        Task DeleteOrderAsync(int orderId);
        Task DeleteOrderItemAsync(int orderId, int orderItemId);
        Task <Order> CancelOrderAsync(int id);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus orderStatus);
        Task CalculateTotalOrderPriceAsync(int orderId);
    }
}
