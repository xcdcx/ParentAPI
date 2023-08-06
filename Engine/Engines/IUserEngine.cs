using Engine.Entities;

namespace Engine.Engines
{
    public interface IUserEngine
    {
        public User Get(UserLogin login);
    }
}
