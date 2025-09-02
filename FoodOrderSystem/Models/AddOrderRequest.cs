namespace FoodOrderSystem.Models
{
    public class AddOrderRequest
    {
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public int CustomerId { get; set; }
        public List<AddOrderItem> OrderItems { get; set; }

    }
}
