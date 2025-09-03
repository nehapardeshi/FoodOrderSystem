using FoodOrderSystem.Orders;
using FoodOrderSystem.Repositories;
using FoodOrderSystem.Services;
using NSubstitute;

namespace FoodOrderSystemTest
{
    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuService _menuService;
        private readonly IMenuRepository _menuRepository;

        public OrderServiceTest()
        {
            // Mocking
            _menuRepository = Substitute.For<IMenuRepository>();
            _orderRepository = Substitute.For<IOrderRepository>();
            _menuRepository = Substitute.For<IMenuRepository>();

            _menuService = new MenuService(_menuRepository);
            _orderService = new OrderService(_orderRepository, _menuRepository);

        }
        [Fact]
        public async Task GetOrderTestAsync()
        {
            // Arrange
            var orderDate = DateTime.Now;
            var expectedOrderStatus = 1;
            var customerId = 12;
            var orderId = 1;
            var expectedOrder = new Order { Id = orderId, CustomerId = customerId, OrderDate = orderDate, OrderStatusId = expectedOrderStatus };

            // Configure the mock to return a specific order when GetOrderAsync is called with the given order ID
            _orderRepository.GetOrderAsync(orderId).Returns(expectedOrder);

            // Act
            var order = await _orderService.GetOrderAsync(orderId);

            //Assert
            Assert.NotNull(order);
            Assert.Equal(orderId, order.Id);
            Assert.Equal(expectedOrderStatus, order.OrderStatusId);
            Assert.Equal(customerId, order.CustomerId);
            Assert.Equal(orderDate, order.OrderDate);
        }
    }
}