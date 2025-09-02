using FoodOrderSystem.Entities;

namespace FoodOrderSystem.Models
{
    public class UpdateOrderRequest
    {
       
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
