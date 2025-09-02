using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.Entities
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // PK
        public int OrderId { get; set; } // FK
        public int MenuId { get; set; } // FK
        public int Quantity { get; set; }
        public decimal MenuPrice { get; set; }       
        public decimal TotalOrderItemPrice { get; set; }
    }
}
