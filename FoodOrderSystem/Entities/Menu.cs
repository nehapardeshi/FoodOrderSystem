using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.Entities
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //PK
        [Column(TypeName = "varchar(250)")]
        public string MenuName { get; set; }
        public int? ChefId { get; set; } // FK
        public List<FoodItem> FoodItems {get; set;} // FK 1 menu many food item
        public decimal MenuPrice { get; set;}
        public DateTime? AvailabilityStartDate { get; set; }
        public DateTime? AvailabilityEndDate { get; set; }
    }
}
