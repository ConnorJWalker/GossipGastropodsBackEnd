using System.Linq;
using GossipGastropodsBackEnd.Entities;
using GossipGastropodsBackEnd.Helpers;
using GossipGastropodsBackEnd.Models.Http.Requests.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GossipGastropodsBackEnd.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [Produces("application/json"), Consumes("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly GossipContext context;
        private readonly IAuthService auth;
        public AuthController(GossipContext context, IAuthService auth)
        {
            this.context = context;
            this.auth = auth;
        }

        [HttpPost("signup")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult SignUp(SignupRequest request)
        {
            if (context.Users.FirstOrDefault(u => u.Email == request.Email.ToLower()) != null)
                return BadRequest(new { Email = new[] { "Email already in use" } });

            return Ok(new { Token = auth.SignUp(request) });
        }

        public IActionResult LogIn(LoginRequest request)
        {
            return NotFound();
        }
    }
}