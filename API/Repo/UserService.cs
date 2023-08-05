using API.Dtos;

namespace API.Repo
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            return UserRepo.Users.FirstOrDefault(o => o.UserName.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && o.Password.Equals(userLogin.Password));
        }
    }
}
