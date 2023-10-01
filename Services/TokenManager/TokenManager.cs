using BasicAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BasicAPI.Services.TokenManager
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration configuration;

        public TokenManager(IConfiguration _configuration) => configuration = _configuration;

        public Token GenerateToken(User _user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(5),
                Audience = configuration["JWT:Audience"],
                Issuer = configuration["JWT:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token { UserToken = tokenHandler.WriteToken(token) };
        }
    }
}