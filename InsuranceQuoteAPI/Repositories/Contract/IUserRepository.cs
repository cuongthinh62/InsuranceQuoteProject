using InsuranceQuoteAPI.Models;

namespace InsuranceQuoteAPI.Repositories.Contract
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserAsync(String name);
        Task<User> AddUserAsync(User user);
        Task<User> UpdatedUserAsync(User user);
        Task<User> DeleteUserAsync(int id);
    }
}
