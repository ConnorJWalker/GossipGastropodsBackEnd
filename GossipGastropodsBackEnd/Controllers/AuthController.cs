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
        public IActionResult SignUp([FromBody] SignupRequest request)
        {
            if (context.Users.FirstOrDefault(u => u.Email == request.Email.ToLower()) != null)
                return BadRequest(new { Email = new[] { "Email already in use" } });

            return Ok(new { Token = auth.SignUp(request) });
        }

        [HttpPost("login")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult LogIn([FromBody] LoginRequest request)
        {
            object error = new { Error = "Incorrect email or password" };
            User user = context.Users.FirstOrDefault(u => u.Email == request.Email.ToLower());
            if (user == null)
                return BadRequest(error);

            string token = auth.LogIn(user, request);
            if (token == null)
                return BadRequest(error);
            return Ok(new { Token = token });
        }
    }
}