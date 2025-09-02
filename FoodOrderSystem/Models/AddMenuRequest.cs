namespace FoodOrderSystem.Models
{
    public class AddMenuRequest
    {
        public string MenuName { get; set; }
        public int ChefId { get; set; } // FK
        public List<FoodItem>? FoodItems { get; set; } // FK 1 menu many food item
        public decimal MenuPrice { get; set; }
        public DateTime? AvailabilityStartDate { get; set; }
        public DateTime? AvailabilityEndDate { get; set; }

    }

    public class FoodItem
    {
        public int FoodTypeId { get; set; } // FK
        public string ItemName { get; set; } = string.Empty; // FK
        public string ItemDescription { get; set; } = string.Empty;
    }
}
