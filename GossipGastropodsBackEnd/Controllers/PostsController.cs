using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipGastropodsBackEnd.Entities;
using GossipGastropodsBackEnd.Helpers;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;
using GossipGastropodsBackEnd.Models.Http.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GossipGastropodsBackEnd.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Produces("application/json"), Consumes("application/json")]
    public class PostsController : ControllerBase
    {
        private readonly GossipContext context;
        private readonly CurrentUser currentUser;
        public PostsController(GossipContext context, IHttpContextAccessor httpContext)
        {
            this.context = context;
            currentUser = httpContext.GetCurrentUser();
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetPosts()
        {
            List<Post> posts = context.Posts.Include(p => p.Owner).ToList();
            return Ok(PostResponse.GetResponseList(posts));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult NewPost(NewPostRequest request)
        {
            Post post = new Post(request, currentUser);
            context.Posts.Add(post);
            context.SaveChanges();

            return Created("", new PostResponse(post, currentUser));
        }
    }
}