using FoodOrderSystem.Entities;

namespace FoodOrderSystem.Services
{
    public interface IChefService
    {
        Task<int> AddChefAsync(string firstName, string lastName, string email, string phone, string address, string city);
        Task<User> GetChefAsync(int userId);
        Task<IEnumerable<User>> GetAllChefAsync();
        Task<User> UpdateChefAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city);
        Task DeleteChefAsync(int userId);



            // chef can add/update/delete a fooditem
            //Task AddMenuFooditem(int id);
            // Task DeleteMenuFooditem(int id);
            // Task GetMenuFoodItem(int id);
            //// Task <MenuFoodItem> UpdateMenuFooditem(int id);

        // // Chef can add/update/delete menu and price
        // Task AddMenuAsync(int id);
        // Task DeleteMenuAsync(int id);
        // Task GetMenuAsync(int id);
        // Task <Menu> UpdateMenuAsync(int id);

        // // chef can add/update/delete date availability

        // Task AddChefAvailability(int id);
        // Task DeleteChefAvailability(int id);
        // Task<Availability> UpdateChefAvailability();

        // Task GetChefAvailability (int id);
        // Task GetChefAsync(int id);
        // Task<User> UpdateChefAsync(User user);
        // Task DeleteChefAsync(int id);
        // Task GetAllChefs();
    }
}
