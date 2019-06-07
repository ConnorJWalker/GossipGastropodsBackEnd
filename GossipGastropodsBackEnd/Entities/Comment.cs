using System;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;

namespace GossipGastropodsBackEnd.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserGuid { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Owner { get; set; }
        public Post Post { get; set; }

        public Comment() { }

        public Comment(NewCommentRequest request, CurrentUser user, int postId)
        {
            Body = request.Body;
            UserGuid = user.GUID;
            PostId = postId;
        }
    }
}
