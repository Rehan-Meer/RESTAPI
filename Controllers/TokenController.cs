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
        private readonly DBContext.ClientDBContext dbContext;
        public TokenController(DBContext.ClientDBContext _dbContext, ITokenManager _tokenManager)
        {
            dbContext = _dbContext;
            tokenManager = _tokenManager;
        }

        [AllowAnonymous]
        [Route(RouteConstants.GenerateToken)]
        [HttpPost]
        public IActionResult TokenManager([FromBody] User _user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var validUser = dbContext.User.FirstOrDefault(user => user.Equals(_user));
                if (validUser != null)
                {
                    var token = tokenManager.GenerateToken(validUser);
                    return Ok(token);
                }
                else
                    return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}