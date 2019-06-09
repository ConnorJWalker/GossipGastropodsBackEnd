using System;
using System.Collections.Generic;
using GossipGastropodsBackEnd.Models;
using GossipGastropodsBackEnd.Models.Http.Requests.Posts;

namespace GossipGastropodsBackEnd.Entities
{
    public class Post : PostBase
    {
        public string FilePaths { get; set; }

        public List<Comment> Comments { get; set; }

        public Post() { }

        public Post(NewPostRequest request, CurrentUser user) : base(request.Body, user.GUID)
        {
            FilePaths = null; // TODO
        }
    }
}
