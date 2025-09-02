using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FoodOrderSystem.Models
{
    public class AddMenuFoodItemRequest
    {
        
           
            public int FoodTypeId { get; set; } // FK
            public string ItemName { get; set; } = string.Empty; // FK
            public string ItemDescription { get; set; } = string.Empty;
            public int MenuId { get; set; } // FK
        
    }
}
