using System;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;

namespace GossipGastropodsBackEnd.Entities
{
    public class Comment : PostBase
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public Comment() { }

        public Comment(NewCommentRequest request, CurrentUser user, int postId) : base (request.Body, user.GUID)
        {
            PostId = postId;
        }
    }
}
