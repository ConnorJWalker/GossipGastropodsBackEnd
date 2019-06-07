using System;
using System.Collections.Generic;
using GossipGastropodsBackEnd.Entities;

namespace GossipGastropodsBackEnd.Models.Http.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public UserResponse Owner { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public DateTime CreatedAt { get; set; }

        public CommentResponse(Comment comment)
        {
            Init(comment);
            Owner = new UserResponse(comment.Owner);
        }

        public CommentResponse(Comment comment, CurrentUser user)
        {
            Init(comment);
            Owner = new UserResponse(user);
        }

        private void Init(Comment comment)
        {
            Id = comment.Id;
            IsEdited = comment.IsEdited;
            Body = comment.Body;
            CreatedAt = comment.CreatedAt;
        }

        public static List<CommentResponse> GetResponseList(List<Comment> comments)
        {
            List<CommentResponse> responseList = new List<CommentResponse>();
            comments.ForEach(comment => responseList.Add(new CommentResponse(comment)));

            return responseList;
        }
    }
}
