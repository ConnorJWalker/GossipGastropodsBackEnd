using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GossipGastropodsBackEnd.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
        public bool IsEdited { get; set; }
        public DateTime CreatedAt { get; set; }

        public User Owner { get; set; }
        public Post Post { get; set; }
    }
}
