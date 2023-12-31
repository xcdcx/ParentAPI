﻿using API.Dtos;
using Engine.Engines;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserEngine _userEngine;
        private readonly IConfiguration _configuration;
        public AuthorizationController(ILogger<AuthorizationController> logger, IUserEngine userEngine, IConfiguration configuration)
        {
            _logger = logger;
            _userEngine = userEngine;
            _configuration = configuration;
        }

        /// <summary>
        /// Authorize client
        /// </summary>
        /// <param name="user"></param>
        /// <returns>authorization token</returns>
        [Route("/authorize")]
        [HttpPost]
        public ActionResult<string> GetTokenController(UserLogin user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
                {
                    var loggedInUser = _userEngine.Get(user.ToEntity()).ToDto();
                    if (loggedInUser is null)
                    {
                        return NotFound("User not found");
                    }

                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, loggedInUser.UserName),
                        new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                        new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
                        new Claim(ClaimTypes.Surname, loggedInUser.Surname),
                        new Claim(ClaimTypes.Role, loggedInUser.Role)
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: _configuration["Jwt:Issuer"],
                        audience: _configuration["Jwt:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddMinutes(15),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                            SecurityAlgorithms.HmacSha256)
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(tokenString);
                }
                return BadRequest("Invalid user credentials");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "User not found");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Authorization");
                throw;
            }
        }
    }
}
