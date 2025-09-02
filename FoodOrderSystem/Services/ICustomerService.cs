using FoodOrderSystem.Entities;

namespace FoodOrderSystem.Services
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(string firstName, string lastName, string email, string phone, string address, string city);
        Task<User> GetCustomerAsync(int userId);
        Task<IEnumerable<User>> GetAllCustomer();
        Task<User> UpdateCustomerAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city);
        Task DeleteCustomerAsync(int customerId);
        



    }
}
