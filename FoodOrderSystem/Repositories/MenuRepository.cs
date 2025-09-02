using FoodOrderSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodOrderSystem.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly FoodOrderDbContext _dbContext;


        public MenuRepository(FoodOrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddMenuAsync(Menu menu)
        {
            await _dbContext.Menu.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task AddMenuFoodItemAsync(FoodItem foodItem)
        {
            await _dbContext.FoodItems.AddAsync(foodItem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteMenuAsync(Menu menu)
        {
            _dbContext.Menu.Remove(menu);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMenuFoodItemAsync(FoodItem foodItem)
        {             
                _dbContext.FoodItems.Remove(foodItem);
                await _dbContext.SaveChangesAsync();
                     
        }

        public async Task<Menu> GetMenuAsync(int id)
        {
            return await _dbContext.Menu.FirstOrDefaultAsync(m=> m.Id == id);
           
        }         
        public async Task<List<Menu>> GetAllMenuAsync(string search, DateTime? dateTime)
        {
            var isSearchNull = string.IsNullOrEmpty(search);
            var menu = new List<Menu>();
            if (isSearchNull && dateTime == null)
            {
                menu = await _dbContext.Menu.ToListAsync();
            }

            if (!isSearchNull)
            {
                search = search.ToLower();
                menu = await _dbContext.Menu.Where(m => m.MenuName.ToLower().Contains(search)
                    || m.Id.Equals(search) || m.MenuPrice.Equals(search)).ToListAsync();
            }

            if (dateTime != null)
            {
                if (menu.Count > 0)
                {
                    menu = menu.Where(m => m.AvailabilityStartDate.Value.Date >= (dateTime.Value.Date) && m.AvailabilityEndDate.Value.Date <= (dateTime.Value.Date)).ToList();
                }
                else
                {
                    menu = await _dbContext.Menu.Where(m => m.AvailabilityStartDate.Value.Date >= (dateTime.Value.Date) && m.AvailabilityEndDate.Value.Date <= (dateTime.Value.Date)).ToListAsync();
                }
            }
            return menu;


        }
        
        public async Task<FoodItem> GetMenuFoodItemAsync(int foodTypeId)
        {
            return await _dbContext.FoodItems.FirstOrDefaultAsync(f=> f.Id == foodTypeId);
        }

        public async Task UpdateMenuFoodItemAsync(FoodItem foodItem)
        {
                        
            _dbContext.FoodItems.Update(foodItem);
           await _dbContext.SaveChangesAsync();
            
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
           
            _dbContext.Menu.Update(menu);
            await _dbContext.SaveChangesAsync();
            
        }
    }
}
