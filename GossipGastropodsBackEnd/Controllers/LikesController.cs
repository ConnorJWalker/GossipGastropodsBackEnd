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

namespace GossipGastropodsBackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json"), Consumes("application/json")]
    public class LikesController : ControllerBase
    {
        private readonly GossipContext context;
        private readonly CurrentUser currentUser;
        public LikesController(GossipContext context, IHttpContextAccessor httpContext)
        {
            this.context = context;
            currentUser = httpContext.GetCurrentUser();
        }

        [HttpPost("comment/{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(203)]
        [ProducesResponseType(404)]
        public IActionResult LikeComment(int id) => AddLike(id, PostType.Comment);

        [HttpPost("post/{id}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(203)]
        [ProducesResponseType(404)]
        public IActionResult LikePost(int id) => AddLike(id, PostType.Post);

        private IActionResult AddLike(int id, PostType type)
        {
            if (type == PostType.Post)
            {
                if (context.Posts.FirstOrDefault(p => p.Id == id) == null)
                    return NotFound();
            }
            else
            {
                if (context.Comments.FirstOrDefault(p => p.Id == id) == null)
                    return NotFound();
            }

            Like like = context.Likes.FirstOrDefault(l => l.PostId == id && l.PostType == type);
            bool isNew = like == null;
            if (isNew)
            {
                like = new Like(id, currentUser, type);
                context.Likes.Add(like);
            }
            else
                context.Likes.Remove(like);

            context.SaveChanges();
            return isNew ? (IActionResult)Created("", null) : NoContent();
        }
    }
}