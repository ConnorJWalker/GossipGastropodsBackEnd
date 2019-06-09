using System;
using System.Collections.Generic;
using GossipGastropodsBackEnd.Entities;

namespace GossipGastropodsBackEnd.Models
{
    public class PostBase
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Owner { get; set; }
        public List<Like> Likes { get; set; }

        public PostBase() { }

        public PostBase(string body, Guid userId)
        {
            Body = body;
            UserGuid = userId;
        }
    }
}
