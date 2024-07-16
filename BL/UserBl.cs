using BL;
using DAL;
using UsersManagement.Entities;

namespace UsersManagement.Application.Services
{
    public class UserBl : IUserBl
    {
        private readonly IRepository _userDal;

        public UserBl(IRepository userRepository)
        {
            _userDal = userRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userDal.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userDal.DeleteUserAsync(userId);
        }

        public async Task<User> GetUserByCredentialsAsync(string userName, string password)
        {
            var user = await _userDal.GetUserByCredentialsAsync(userName, password);
            if (user != null ) 
            {
                return user;
            }
            return null;
        }
    }


}
