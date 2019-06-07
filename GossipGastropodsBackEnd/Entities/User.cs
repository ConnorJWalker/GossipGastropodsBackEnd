using System;
using GossipGastropodsBackEnd.Models.Http.Requests.Auth;

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
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            ProfilePicture = defaultProfilePicture;
        }
    }
}
