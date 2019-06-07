using System;
using Microsoft.AspNetCore.Http;

namespace GossipGastropodsBackEnd.Models
{
    public class CurrentUser
    {
        public Guid GUID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public bool EmailVerified { get; set; }

        public CurrentUser(IHttpContextAccessor httpContext)
        {
            GUID = Guid.Parse(httpContext?.HttpContext?.User?.FindFirst("guid")?.Value);
            FirstName = httpContext?.HttpContext?.User?.FindFirst("firstName")?.Value;
            LastName = httpContext?.HttpContext?.User?.FindFirst("lastName")?.Value;
            ProfilePicture = httpContext?.HttpContext?.User?.FindFirst("profilePicture")?.Value;
            EmailVerified = bool.Parse(httpContext?.HttpContext?.User?.FindFirst("VerifiedEmail")?.Value);
        }
    }
}
