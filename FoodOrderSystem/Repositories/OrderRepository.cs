using FoodOrderSystem.Entities;
using FoodOrderSystem.Orders;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodOrderSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodOrderDbContext _dbContext;
        public OrderRepository(FoodOrderDbContext context)
        {
            _dbContext = context;
        }
       

        public async Task AddOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
           
        }
        public async Task AddOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteOrderAsync(Order order)
        {
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            var orderWithItems = await _dbContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);                   

            return orderWithItems;
        }
        public Task<OrderItem> GetOrderItemAsync(int id)
        {
            return _dbContext.OrderItems.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<OrderItem>> GetAllOrderItemAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }
        public async Task UpdateOrderAsync(Order order)
        {
            
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task DeleteOrderItemAsync(int orderId, int orderItemId)
        {            
             _dbContext.Remove(orderItemId);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Update(orderItem);

            await _dbContext.SaveChangesAsync();
                                
        }

        public async Task<List<Order>>GetOrdersByCustomerIdAsync(int customerId)
        {
            var order = await _dbContext.Orders.Where(c => c.CustomerId == customerId).ToListAsync();

            return order.ToList();

        }

        //public async Task CalculateTotalPriceAsync(int orderId, OrderItem orderItem)
        //{
        //    var ordItems = await _dbContext.OrderItems.Where(o => o.Id == orderId).ToListAsync();
        //    var totalOrderItemPrice = (orderItem.Quantity * orderItem.MenuPrice);
            
        //    await _dbContext.SaveChangesAsync();

        //}


    }
}
