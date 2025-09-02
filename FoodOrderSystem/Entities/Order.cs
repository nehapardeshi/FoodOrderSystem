using FoodOrderSystem.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.Orders
{
  
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // PK 
        public List<OrderItem> OrderItems { get; set; }
        public int CustomerId { get; set; } // FK
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime DeliveryDate { get; set; }
        public int OrderStatusId { get; set; } // FK
        public decimal ServiceFee { get; set; }
        public string DeliveryAddress { get; set; }



    }
}
