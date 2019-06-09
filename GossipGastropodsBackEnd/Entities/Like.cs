using GossipGastropodsBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GossipGastropodsBackEnd.Entities
{
    public enum PostType : byte
    {
        Post, Comment
    }

    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserGuid { get; set; }
        public PostType PostType { get; set; }

        public User Owner { get; set; }
        public PostBase Post { get; set; }
    }
}
