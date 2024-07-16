using UsersManagement.Entities;

namespace BL
{
    public interface IUserBl
    {
        Task<User> CreateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<User> GetUserByCredentialsAsync(string userName, string password);
    }

}