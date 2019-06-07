using System.ComponentModel.DataAnnotations;

namespace GossipGastropodsBackEnd.Models.Http.Requests.Posts
{
    public class NewCommentRequest
    {
        [MinLength(3, ErrorMessage = "Comment body must be at least 3 charters long")]
        public string Body { get; set; }
    }
}
