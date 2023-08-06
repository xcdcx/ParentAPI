using Service.Models;

namespace Service.Services
{
    public interface IUserService
    {
        /// <summary>
        /// Get user by login information
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns>user</returns>
        public User Get(UserLogin userLogin);
    }
}
