using InsuranceQuoteAPI.Data;
using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace InsuranceQuoteAPI.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private InsuranceQuoteContext _context;

        public UserRepository(InsuranceQuoteContext context)
        {
            _context = context;
        }
        public async Task<User> AddUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            var FindUserDelete = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if(FindUserDelete != null)
            {
                _context.Users.Remove(FindUserDelete);
                await _context.SaveChangesAsync();
            }
            return FindUserDelete;

        }

        public async Task<User?> GetUserAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var ListUsers = await _context.Users.ToListAsync();
            return ListUsers;
        }

        public async Task<User> UpdatedUserAsync(User user)
        {
             var AccountUpdate = _context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (AccountUpdate != null) { 
                AccountUpdate.FullName = user.FullName;
                _context.Users.Update(AccountUpdate);
                await _context.SaveChangesAsync();
            }
            return AccountUpdate;
        }
    }
}
