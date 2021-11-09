using ESS.Amanse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Account : ControllerBase
    {
        public IConfiguration _configuration;
        public Account(IConfiguration config)
        {
            _configuration = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AuthData model)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(model);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private AuthData AuthenticateUser(AuthData login)
        {
            AuthData user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.UserName == "Jignesh")
            {
                user = new AuthData { UserName = "Jignesh Trivedi", Password = "test.btest@gmail.com" };
            }
            return user;
        }
        private string GenerateJSONWebToken(AuthData userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult JWTLogin(AuthData model)
        {
            //string username = HttpContext.Request.Headers["username"];
            //string password = HttpContext.Request.Headers["password"];

            if (model.UserName == "test" && model.Password== "test")
            {
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("username", model.UserName),
                    new Claim("password", model.Password),
                   };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }

        }
    }
}
