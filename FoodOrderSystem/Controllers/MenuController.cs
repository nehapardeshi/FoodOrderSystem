using FoodOrderSystem.Models;
using FoodOrderSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystem.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }
        [HttpPost]
        public async Task<IActionResult> AddMenuAsync([FromBody] AddMenuRequest request)
        {
            if (request.AvailabilityStartDate < request.AvailabilityEndDate)
            {
                var menuId = await _menuService.AddMenuAsync(request.ChefId, request.MenuName, request.MenuPrice, request.AvailabilityStartDate, request.AvailabilityEndDate);


                if (request.FoodItems != null && request.FoodItems.Any())
                {
                    foreach (var foodItem in request.FoodItems)
                    {
                        await _menuService.AddMenuFoodItemAsync(menuId, foodItem.FoodTypeId, foodItem.ItemName, foodItem.ItemDescription);

                    }
                }

                return Ok(menuId);
            }
            throw new Exception($"Check dates Please");
        }

        [HttpPost]
        [Route("{menuId}/food-items")]
        public async Task<IActionResult> AddMenuFoodItemAsync(int menuId, [FromBody] AddMenuFoodItemRequest request)
        {
            var itemId = await _menuService.AddMenuFoodItemAsync(request.MenuId, request.FoodTypeId, request.ItemName, request.ItemDescription);
            return Ok(itemId);
        }
        [HttpGet]
        [Route("{menuId}")]
        public async Task<IActionResult> GetMenuAsync([FromRoute] int menuId)
        {
            var menu = await _menuService.GetMenuAsync(menuId);
            return Ok(menu);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuAsync(string? search,  DateTime? dateTime)
        {
            var menu = await _menuService.GetAllMenuAsync(search, dateTime);
            return Ok(menu);
        }

        [HttpGet]
        [Route("{menuId}/food-items/{foodItemId}")]
        public async Task<IActionResult> GetMenuFoodItemAsync([FromRoute] int foodItemId)
        {
            var item = await _menuService.GetMenuFoodItemAsync(foodItemId);
            return Ok(item);
        }
        [HttpPut]
        [Route("{menuId}")]
        public async Task<IActionResult> UpdateMenuAsync(int menuId, [FromBody] UpdateMenuRequest request)
        {
            var menu = await _menuService.GetMenuAsync(menuId);
            if (menu == null)
            {
                return BadRequest($"Menu not found with this id: {menuId}");
            }
               
                await _menuService.UpdateMenuAsync(menuId, request.MenuName, request.MenuPrice, request.ChefId, request.AvailabilityStartDate, request.AvailabilityEndDate);
                return Ok();
            
        }
        [HttpPut]
        [Route("{menuId}/food-items/{foodItemId}")]
        public async Task<IActionResult> UpdateMenuFoodItemAsync(int menuId, int foodItemId, [FromBody] UpdateMenuFoodItemRequest request)
        {
            var menu = await GetMenuAsync(menuId);
            if(menu == null)
            {
                return BadRequest($"MenuItem not found with this id: {foodItemId}");
            }
            var item = await _menuService.UpdateMenuFoodItemAsync(menuId, foodItemId, request.ItemName, request.ItemDescription);
            return Ok(item);
            

        }

        [HttpDelete]
        [Route("{menuId}")]
        public async Task<IActionResult> DeleteMenuAsync([FromRoute] int menuId)
        {
            var menu = await _menuService.GetMenuAsync(menuId);
            if (menu == null)
                return BadRequest($"Menu not found with this id: {menuId}");
            await _menuService.DeleteMenuAsync(menuId);
            return Ok();
        }

        [HttpDelete]
        [Route("{menuId}/food-items/{foodItemId}")]
        public async Task<IActionResult> DeleteMenuFoodItemAsync([FromRoute] int foodItemId)
        {
            var item = await _menuService.GetMenuFoodItemAsync(foodItemId);
            if(item == null)
                return BadRequest($"FoodItem was not found with this id: {foodItemId}");
            await _menuService.DeleteMenuFoodItemAsync(foodItemId);
            return Ok();
        }





    }
}
