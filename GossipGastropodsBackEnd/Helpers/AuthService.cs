﻿using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GossipGastropodsBackEnd.Entities;
using GossipGastropodsBackEnd.Models.Http.Requests.Auth;

namespace GossipGastropodsBackEnd.Helpers
{
    public interface IAuthService
    {
        string GenerateJwt(User user);
        string SignUp(SignupRequest request);
        string LogIn(User user, LoginRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly EnvironmentSettings env;
        private readonly GossipContext context;
        public AuthService(IOptions<EnvironmentSettings> env, GossipContext context)
        {
            this.env = env.Value;
            this.context = context;
        }

        public string SignUp(SignupRequest request)
        {
            User user = new User(request, env.DefaultProfilePicture);
            context.Users.Add(user);
            context.SaveChanges();

            return GenerateJwt(user);
        }

        public string LogIn(User user, LoginRequest request)
        {
            if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return GenerateJwt(user);
            else
                return null;
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
