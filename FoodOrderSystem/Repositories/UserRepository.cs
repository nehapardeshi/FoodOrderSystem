using FoodOrderSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodOrderSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodOrderDbContext _dbContext;

        public UserRepository(FoodOrderDbContext _context)
        {
            _dbContext = _context;
        }

        public async Task AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return  await _dbContext.Users.ToListAsync();
            

        }        

        public async Task UpdateUserAsync(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

    }
}
