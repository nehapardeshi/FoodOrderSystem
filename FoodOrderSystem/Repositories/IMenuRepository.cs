using FoodOrderSystem.Entities;

namespace FoodOrderSystem.Repositories
{
    public interface IMenuRepository
    {
        Task AddMenuAsync(Menu menu);
        Task AddMenuFoodItemAsync(FoodItem foodItem);
        Task DeleteMenuAsync(Menu menu);
        Task DeleteMenuFoodItemAsync(FoodItem foodItem);
        Task <Menu> GetMenuAsync(int id);
        Task<List<Menu>> GetAllMenuAsync(string search, DateTime? dateTime);
        Task <FoodItem> GetMenuFoodItemAsync(int foodTypeId);
        Task UpdateMenuFoodItemAsync(FoodItem fooditem);
        Task UpdateMenuAsync(Menu menu);
    }
}
