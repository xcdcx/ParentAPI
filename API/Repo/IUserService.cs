using API.Dtos;

namespace API.Repo
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
