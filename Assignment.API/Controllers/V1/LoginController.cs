using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Assignment.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            IActionResult response = Unauthorized();
            bool IsValidUser = AuthenticateUser( username,  password);

            if (IsValidUser)
            {
                var tokenString = GenerateJSONWebToken(username);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool AuthenticateUser(string username, string password)
        {
           
            //Validate the User Credentials
            //Demo Purpose, I have Passed HardCoded User Information
            if (username == "user1" && password=="password")
            {
                return true;
            }
            return false;
        }
    }
}
