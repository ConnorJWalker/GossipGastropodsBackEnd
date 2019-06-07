using System.ComponentModel.DataAnnotations;

namespace GossipGastropodsBackEnd.Models.Http.Requests.Posts
{
    public class NewPostRequest
    {
        [MinLength(5, ErrorMessage = "Post body must be at least 5 charters long")]
        public string Body { get; set; }
    }
}
