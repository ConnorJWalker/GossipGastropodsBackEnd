using System;

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
    }
}
