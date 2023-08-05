using API.Dtos;

namespace API.Repo
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
