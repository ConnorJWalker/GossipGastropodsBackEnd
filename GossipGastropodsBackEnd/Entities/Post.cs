using System;
using System.Collections.Generic;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;

namespace GossipGastropodsBackEnd.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public string FilePaths { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Owner { get; set; }
        public List<Comment> Comments { get; set; }

        public Post() { }

        public Post(NewPostRequest request, CurrentUser user)
        {
            UserGuid = user.GUID;
            Body = request.Body;
            FilePaths = null; // TODO
        }
    }
}
