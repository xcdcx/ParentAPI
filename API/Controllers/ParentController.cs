using API.Dtos;
using API.Repo;
using Engine;
using Engine.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly ILogger _logger;
        //private readonly IUserService _userService;
        //private readonly IConfiguration _configuration;
        private readonly IEngine _engine;
        public ParentController(ILogger<ParentController> logger, /*IUserService userService, IConfiguration configuration,*/ IEngine engine)
        {
            _logger = logger;
            //_userService = userService;
            //_configuration = configuration;
            _engine = engine;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        [HttpPost]
        public ActionResult<IEnumerable<PersonResponseDto>> BuildTree(IEnumerable<PersonDto> request)
        {
            try
            {
                IEnumerable<PersonNode> response = _engine.CreateTree(request.ToEntity());
                //return Ok(response);
                return Ok(response.ToDto());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        //[Route("/Token")]
        //[HttpPost]
        //public ActionResult<string> GetToken(UserLogin user)
        //{
        //    if (!string.IsNullOrEmpty(user.Username) &&
        //        !string.IsNullOrEmpty(user.Password))
        //    {
        //        var loggedInUser = _userService.Get(user);
        //        if (loggedInUser is null) return NotFound("User not found");

        //        var claims = new[]
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserName),
        //            new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
        //            new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
        //            new Claim(ClaimTypes.Surname, loggedInUser.Surname),
        //            new Claim(ClaimTypes.Role, loggedInUser.Role)
        //        };

        //        var token = new JwtSecurityToken
        //        (
        //            issuer: _configuration["Jwt:Issuer"],
        //            audience: _configuration["Jwt:Audience"],
        //            claims: claims,
        //            expires: DateTime.UtcNow.AddDays(60),
        //            notBefore: DateTime.UtcNow,
        //            signingCredentials: new SigningCredentials(
        //                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
        //                SecurityAlgorithms.HmacSha256)
        //        );

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        //        return Ok(tokenString);
        //    }
        //    return BadRequest("Invalid user credentials");
        //}
    }
}
