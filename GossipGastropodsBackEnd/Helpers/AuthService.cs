using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GossipGastropodsBackEnd.Entities;

namespace GossipGastropodsBackEnd.Helpers
{
    public interface IAuthService
    {
        string GenerateJwt(User user);
    }

    public class AuthService : IAuthService
    {
        private readonly EnvironmentSettings env;
        public AuthService(IOptions<EnvironmentSettings> env)
        {
            this.env = env.Value;
        }

        public string GenerateJwt(User user)
        {
            byte[] key = Encoding.UTF8.GetBytes(env.Jwt.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("guid", user.GUID.ToString()),
                    new Claim("firstName", user.FirstName),
                    new Claim("lastName", user.LastName),
                    new Claim("profilePicture", user.ProfilePicture),
                    new Claim("VerifiedEmail", user.EmailVerified.ToString())
                }),
                Expires = DateTime.Now.AddDays(env.Jwt.Expiry),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
