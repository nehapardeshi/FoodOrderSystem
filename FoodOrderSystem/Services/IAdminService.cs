using FoodOrderSystem.Entities;
using FoodOrderSystem.Orders;

namespace FoodOrderSystem.Services
{
    public interface IAdminService
    {


        Task<int> AddAdminAsync(string firstName, string lastName, string email, string phone, string address, string city);
        Task<User> GetAdminAsync(int id);
        Task GetAllAdminAsync();
        Task<User> UpdateAdminAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city);
        Task DeleteAdminAsync(int userId);
        //// Admin can add/ update/delete chef
        //Task AddchefAsync(int id);
        //Task <User> UpdateChefAsync(User user);
        //Task DeleteChefAsync(int id);


        //// Admin can add/update/ delete menu
        //Task AddMenuAsync(int id);
        //Task AddMenuItemAsync(int id);
        //Task DeleteMenuItemAsync(int id);
        //Task<Menu> GetMenuAsync(int id);

        //Task<Menu> UpdateMenuAsync(Menu menu);
        //Task<Menu> UpdateMenuItemAsync(int id);


        //// admin can approve/reject or cancel order
        //Task<Order> ApproveOrder(Order order);

        //Task CancelOrder(Order order);
        //Task GetAdminAsync(int id);
        //Task<User> UpdateAdminAsync(User user);       
        //Task GetAllAdmins();
    }
}
