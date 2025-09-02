using FoodOrderSystem.Entities;
using FoodOrderSystem.Repositories;

namespace FoodOrderSystem.Services
{
    public class MenuService : IMenuService
    {
        // chef can add/update/delete a fooditem
        // Chef can add/update/delete menu and price
        // chef can add/update/delete date availability

        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<int> AddMenuAsync(int chefId, string menuName, decimal price, DateTime? startDateTime, DateTime? endDateTime)
        {
            var menu = new Menu
            {
                ChefId = chefId,
                MenuName = menuName,
                MenuPrice = price
            };

            if (startDateTime.HasValue)
            {
                menu.AvailabilityStartDate = startDateTime.Value.Date;
            }

            if (endDateTime.HasValue)
            {
                menu.AvailabilityEndDate = endDateTime.Value.Date;
            }

            await _menuRepository.AddMenuAsync(menu);

            return menu.Id;
        }
        public async Task<int> AddMenuFoodItemAsync(int menuId, int foodTypeId, string itemName, string itemDescription)
        {
            var foodItem = new FoodItem
            {
                ItemDescription = itemDescription,
                ItemName = itemName,
                FoodTypeId = foodTypeId,
                MenuId = menuId,
                
            };
            await _menuRepository.AddMenuFoodItemAsync(foodItem);
            return foodItem.Id;

        }

        public async Task<Menu> GetMenuAsync(int menuId)
        {
            var menu = await _menuRepository.GetMenuAsync(menuId)?? throw new Exception($"Menu not found with this id:{menuId}");
            return menu;
        }
        public async Task<List<Menu>> GetAllMenuAsync(string search, DateTime? dateTime)
        {
            //According to date availability
            var menu = await _menuRepository.GetAllMenuAsync(search, dateTime);
            return menu;

        }
        public async Task<FoodItem> GetMenuFoodItemAsync(int foodItemId)
        {
            var foodItem = await _menuRepository.GetMenuFoodItemAsync(foodItemId)?? throw new Exception($"Food Item not found: {foodItemId}");
            return foodItem;
        }

        public async Task<Menu> UpdateMenuAsync(int menuId, string menuName, decimal menuPrice, int chefId, DateTime? startDateTime, DateTime? endDateTime)
        {
            var menu = await GetMenuAsync(menuId)?? throw new Exception($"Menu not found:{menuId}");
            menu.MenuPrice = menuPrice;
            menu.ChefId = chefId;  
            menu.MenuName = menuName;
            if (startDateTime.HasValue)
            {
                menu.AvailabilityStartDate = startDateTime.Value.Date;
            }

            if (endDateTime.HasValue)
            {
                menu.AvailabilityEndDate = endDateTime.Value.Date;
            }

            await _menuRepository.UpdateMenuAsync(menu);
            return menu;

        }

        public async Task<FoodItem> UpdateMenuFoodItemAsync(int menuId, int foodItemId, string itemName, string itemDescription)
        { 
            var item = await GetMenuFoodItemAsync(foodItemId)?? throw new Exception($"FoodItem not found: {foodItemId}");
            item.ItemDescription = itemDescription;
            item.ItemName = itemName;
            await _menuRepository.UpdateMenuFoodItemAsync(item);
            return item;
        }
        public async Task DeleteMenuAsync(int menuId)
        {
            var menu = await GetMenuAsync(menuId)?? throw new Exception($"Menu not found with this id: {menuId}");
            await _menuRepository.DeleteMenuAsync(menu);
        }

        public async Task DeleteMenuFoodItemAsync(int foodItemId)
        {
            var foodItem = await GetMenuFoodItemAsync(foodItemId)?? throw new Exception($"FoodItem not found with this id: {foodItemId}");
            await _menuRepository.DeleteMenuFoodItemAsync(foodItem);
        }





    }
}
