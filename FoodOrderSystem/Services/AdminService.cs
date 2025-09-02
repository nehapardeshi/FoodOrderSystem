using FoodOrderSystem.Entities;
using FoodOrderSystem.Repositories;

namespace FoodOrderSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;

        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> AddAdminAsync(string firstName, string lastName, string email, string phone, string address, string city)
        {
            var admin = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                City = city,
                RoleId = 1
            };
            await _userRepository.AddUserAsync(admin);
            return admin.Id;

        }

        public async Task<User> GetAdminAsync(int id)
        {
            var admin = await _userRepository.GetUserAsync(id) ?? throw new Exception($"User not found with this id: {id}");
            return admin;
        }

        public async Task GetAllAdminAsync()
        {
            await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> UpdateAdminAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city)
        // Admin can add/ update/delete chef
        {
            var admin = await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
            admin.Address = address;
            admin.City = city;
            admin.FirstName = firstName;
            admin.LastName = lastName;
            admin.Email = email;
            admin.Phone = phone;
            await _userRepository.UpdateUserAsync(admin);
            return admin;
        }

        public async Task DeleteAdminAsync(int userId)
        {
            var admin = await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
            await _userRepository.DeleteUserAsync(admin);

        }

        // Admin can add/update/ delete menu

        // admin can approve/reject or cancel order

    }
}
