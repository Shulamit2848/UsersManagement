using UsersManagement.Entities;

namespace DAL
{
    public interface IRepository
    {
        Task<User> CreateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> GetUserByCredentialsAsync(string userName, string password);
    }

}