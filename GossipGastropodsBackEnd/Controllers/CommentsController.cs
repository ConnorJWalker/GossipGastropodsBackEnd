using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Helpers;
using GossipGastropodsBackEnd.Entities;
using GossipGastropodsBackEnd.Models.Http.Responses;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;

namespace GossipGastropodsBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json"), Consumes("application/json")]
    public class CommentsController : ControllerBase
    {
        private readonly GossipContext context;
        private readonly CurrentUser currentUser;
        public CommentsController(GossipContext context, IHttpContextAccessor httpContext)
        {
            this.context = context;
            currentUser = httpContext.GetCurrentUser();
        }

        [HttpPost("{postId}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult NewComment(int postId, [FromBody] NewCommentRequest request)
        {
            if (context.Posts.FirstOrDefault(p => p.Id == postId) == null)
                return NotFound();

            Comment comment = new Comment(request, currentUser, postId);
            context.Comments.Add(comment);
            context.SaveChanges();
            return Ok(new CommentResponse(comment, currentUser));
        }
    }
}
