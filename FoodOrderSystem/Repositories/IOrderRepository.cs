using FoodOrderSystem.Entities;
using FoodOrderSystem.Orders;

namespace FoodOrderSystem.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task AddOrderItemAsync(OrderItem orderItem);
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(Order order);
        Task DeleteOrderItemAsync(int orderId, int orderItemId);
        Task<Order> GetOrderAsync(int id);
        Task<OrderItem> GetOrderItemAsync(int id);
        Task<List<OrderItem>> GetAllOrderItemAsync();
        Task UpdateOrderItemAsync(OrderItem orderItem);
        Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId);
        //Task CalculateTotalPriceAsync(int orderId, OrderItem orderItem);
    }
}
