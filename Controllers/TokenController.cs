using BasicAPI.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly BreakfastContext _dbContext;
        public TokenController(IConfiguration config, BreakfastContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        [Route(RouteConstants.GenerateToken)]
        [HttpPost]
        public ActionResult TokenManager(User _user)
        {
            if (!_dbContext.User.IsNullOrEmpty())
            {
                User? user = _dbContext.User.First(user => user.Equals(_user));
                if (user != null)
                {
                    var token = TokenGenerator();
                    return Ok(token);
                }
                else
                    return Unauthorized();
            }
            else
                return NotFound();
        }

        private string TokenGenerator()
        {
            SymmetricSecurityKey SecurityKey = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
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