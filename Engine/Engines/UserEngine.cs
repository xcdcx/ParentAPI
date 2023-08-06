
using Engine.Entities;
using Microsoft.Extensions.Logging;
using Service.Services;

namespace Engine.Engines
{
    public class UserEngine : IUserEngine
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public UserEngine(ILogger<UserEngine> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        public User Get(UserLogin login)
        {
            User result = null;
            try
            {
                var user = _userService.Get(login.ToModel());
                if(user == null)
                {
                    throw new UnauthorizedAccessException("wrong credentials");
                }
                result = user.ToEntity();
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "User not found");
                throw;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error in UserEngine.Get");
                throw;
            }
            return result;
        }
    }
}
