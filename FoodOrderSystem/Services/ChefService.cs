using FoodOrderSystem.Entities;
using FoodOrderSystem.Repositories;

namespace FoodOrderSystem.Services
{
    public class ChefService  : IChefService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMenuRepository _menuRepository;
        
        public ChefService(IUserRepository userRepository, IMenuRepository menuRepository)
        {
            _userRepository = userRepository;
            _menuRepository = menuRepository;
        }
        // chef can add/update/delete a fooditem
        // Chef can add/update/delete menu and price
        // chef can add/update/delete date availability
        public async Task<int> AddChefAsync(string firstName, string lastName, string email, string phone, string address, string city)
        {
            var chef = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                Address = address,
                City = city,
                RoleId = 2                
            };
            await _userRepository.AddUserAsync(chef);
            return chef.Id;

        }
        public async Task<User> GetChefAsync(int userId)
        {
            var chef = await _userRepository.GetUserAsync(userId)?? throw new Exception($"User not found with this id: {userId}");
            return chef;
        }
        public async Task<IEnumerable<User>> GetAllChefAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
        public async Task<User> UpdateChefAsync(int userId, string firstName, string lastName, string email, string phone, string address, string city)
        {
            var chef = await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
            chef.FirstName = firstName;
            chef.LastName = lastName;
            chef.Email = email;
            chef.Phone = phone;
            chef.Address = address;

            await _userRepository.UpdateUserAsync(chef);
            return chef;
        }
        public async Task DeleteChefAsync(int userId)
        {
            var chef = await _userRepository.GetUserAsync(userId) ?? throw new Exception($"User not found with this id: {userId}");
            await _userRepository.DeleteUserAsync(chef);
        }
    }
}
