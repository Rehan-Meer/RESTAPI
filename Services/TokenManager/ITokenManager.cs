using BasicAPI.Models;

namespace BasicAPI.Services.TokenManager
{
    public interface ITokenManager
    {
        public Token GenerateToken(User _user);
    }
}