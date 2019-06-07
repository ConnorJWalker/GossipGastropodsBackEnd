using System;
using System.Collections.Generic;
using GossipGastropodsBackEnd.Entities;

namespace GossipGastropodsBackEnd.Models.Http.Responses
{
    public class PostResponse
    {
        public int Id { get; set; }
        public UserResponse Owner { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public string FilePaths { get; set; }
        public DateTime CreatedAt { get; set; }

        public PostResponse(Post post)
        {
            Id = post.Id;
            Owner = new UserResponse(post.Owner);
            Body = post.Body;
            IsEdited = post.IsEdited;
            FilePaths = post.FilePaths;
            CreatedAt = post.CreatedAt;
        }

        public static List<PostResponse> GetResponseList(List<Post> posts)
        {
            List<PostResponse> responseList = new List<PostResponse>();
            posts.ForEach(post => responseList.Add(new PostResponse(post)));

            return responseList;
        }
    }
}
