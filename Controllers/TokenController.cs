using BasicAPI.DBContext;
using BasicAPI.Services.TokenManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route(RouteConstants.TokenController)]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManager tokenManager;
        private readonly DBContext.DBContext dbContext;
        public TokenController(DBContext.DBContext _dbContext, ITokenManager _tokenManager)
        {
            dbContext = _dbContext;
            tokenManager = _tokenManager;
        }

        [AllowAnonymous]
        [Route(RouteConstants.GenerateToken)]
        [HttpPost]
        public IActionResult TokenManager(User _user)
        {
            var validUser = dbContext.User.First(user => user.Equals(_user));
            if (validUser != null)
            {
                var token = tokenManager.GenerateToken(validUser);
                return Ok(token);
            }
            else
                return Unauthorized();
        }
    }
}