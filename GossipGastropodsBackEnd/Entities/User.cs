using System;
using System.Security.Cryptography;
using GossipGastropodsBackEnd.Models.Http.Requests.Auth;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GossipGastropodsBackEnd.Entities
{
    public class User
    {
        public Guid GUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public bool EmailVerified { get; set; }

        public User() { }

        public User(SignupRequest request, string defaultProfilePicture)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email.ToLower();
            Password = HashPassword(request.Password);
            ProfilePicture = defaultProfilePicture;
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
        }
    }
}
