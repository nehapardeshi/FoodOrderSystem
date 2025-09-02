using FoodOrderSystem.Entities;

namespace FoodOrderSystem.Services
{
    public interface IMenuService
    {
        Task<int> AddMenuAsync(int chefId, string menuName, decimal price, DateTime? startDateTime, DateTime? endDateTime);
        Task<int> AddMenuFoodItemAsync(int menuId, int foodTypeId, string itemName, string itemDescription);
        Task<Menu> GetMenuAsync(int menuId);
        Task<List<Menu>> GetAllMenuAsync(string search, DateTime? dateTime);
        Task<FoodItem> GetMenuFoodItemAsync(int foodItemId);
        Task DeleteMenuFoodItemAsync(int foodItemId);
        Task<Menu> UpdateMenuAsync(int menuId, string menuName, decimal menuPrice, int chefId, DateTime? startDateTime, DateTime? endDateTime);
        Task<FoodItem> UpdateMenuFoodItemAsync(int menuId, int foodItemId, string itemName, string itemDescription);
        Task DeleteMenuAsync(int menuId);

    }
}
