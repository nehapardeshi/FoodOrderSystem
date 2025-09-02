using FoodOrderSystem.Entities;
using FoodOrderSystem.Repositories;

namespace FoodOrderSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUserRepository _userRepository;

        public CustomerService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddCustomerAsync(string firstName, string lastName, string email, string phone, string address, string city)
        {
            var customer = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                City = city,
                RoleId = 3
            };
            await _userRepository.AddUserAsync(customer);
            return customer.Id;

        }
        public async Task<User> GetCustomerAsync(int userId)
        {
            return await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
        }
        public async Task<IEnumerable<User>> GetAllCustomer()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> UpdateCustomerAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city)
        {
            var customer = await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.Phone = phone;
            customer.Address = address;
            customer.City = city;
             await _userRepository.UpdateUserAsync(customer);
            return customer;
        }
        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _userRepository.GetUserAsync(customerId) ?? throw new Exception($"User not found with this id: {customerId}");
            await _userRepository.DeleteUserAsync(customer);
        }
    }
}
