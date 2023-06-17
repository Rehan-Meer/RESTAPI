using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route(RouteConstants.TokenController)]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        public TokenController(IConfiguration config) => _config = config;

        [Route(RouteConstants.GenerateToken)]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult TokenManager(User user)
        {
            string token = user != null ? TokenGenerator() : string.Empty;
            return Ok(token);
        }

        private string TokenGenerator()
        {
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

