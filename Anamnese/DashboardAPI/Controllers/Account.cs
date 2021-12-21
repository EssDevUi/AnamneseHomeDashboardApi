using ESS.Amanse.BLL.ICollection;
using ESS.Amanse.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace DashboardAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class Account : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IProfile _Profile;
        private readonly IPractice _Practice;

        public Account(IConfiguration config, IProfile Profile, IPractice Practice)
        {
            _configuration = config;
            _Profile = Profile;
            _Practice = Practice;

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Login")]
        public IActionResult Login([FromBody] AuthData model)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(model);

            if (user != null)
            {
                var set = _Practice.getPractice(1);
                app_optionsViewModel setting = new app_optionsViewModel();
                if (set!=null)
                {
                    setting.NavigateTo = set.NavigateTo;
                }
                var tokenString = GenerateJSONWebToken();
                response = Ok(new { token = tokenString, setting = setting });
            }

            return response;
        }
        [Authorize]
        [HttpPost]
        [Route("api/checkPassword")]
        public bool checkDangerZonePassword()
        {

            var practice = _Practice.getPractice(1);
            if (practice != null)
            {
                return practice.DangerZonePassword.ToLower() == Request.Headers["passwordKey"].ToString().ToLower() ? true : false;
            }
            return false;
        }
        private AuthData AuthenticateUser(AuthData login)
        {
            AuthData user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (_Profile.loginUser(login.UserName, login.Password))
            {
                user = new AuthData { UserName = login.UserName, Password = login.Password };
            }
            return user;
        }
        private string GenerateJSONWebToken()
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

        //[Route("api/[controller]")]
        //[HttpPost]
        //public IActionResult JWTLogin(AuthData model)
        //{
        //    //string username = HttpContext.Request.Headers["username"];
        //    //string password = HttpContext.Request.Headers["password"];

        //    if (model.UserName == "test" && model.Password == "test")
        //    {
        //        var claims = new[] {
        //            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //            new Claim("username", model.UserName),
        //            new Claim("password", model.Password),
        //           };

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        //        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

        //        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid credentials");
        //    }

        //}
    }
}
