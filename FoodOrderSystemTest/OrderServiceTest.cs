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
           _menuRepository = Substitute.For<IMenuRepository>();
            _orderRepository = Substitute.For<IOrderRepository>();
            _menuService = new MenuService(_menuRepository);
            _orderService = new OrderService(_orderRepository, _menuRepository);
            
            _menuRepository = Substitute.For<IMenuRepository>();
        }
        [Fact]
        public async Task AddOrderTestAsync()
        {
            // Arrange
            var OrderDate = DateTime.Now;
            var expectedOrderStatus = 1;
            var CustomerId = 6;               
            var DeliveryDate = DateTime.Now;
            var DeliveryAddress = "Solbergskolen";
            var ServiceFee = 0;

            // Act
            var order = await _orderService.AddOrderAsync(CustomerId, DeliveryDate, DeliveryAddress, ServiceFee);

            //Assert
            Assert.NotNull(order);
            Assert.Equal(expectedOrderStatus, order.orderStatus);
            Assert.Equal(CustomerId, order.)

        }
    }
}