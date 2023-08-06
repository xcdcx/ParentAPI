using API.Dtos;

namespace API.Repo
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Get user by login information
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>user</returns>
        public User Get(UserLogin userLogin)
        {
            return UserRepo.Users.FirstOrDefault(o => o.UserName.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.Password));
        }
    }
}
