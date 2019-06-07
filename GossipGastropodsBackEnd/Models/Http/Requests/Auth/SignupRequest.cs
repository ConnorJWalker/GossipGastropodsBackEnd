using System.ComponentModel.DataAnnotations;

namespace GossipGastropodsBackEnd.Models.Http.Requests.Auth
{
    public class SignupRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "First Name must be at least 3 characters long")]
        [MaxLength(25, ErrorMessage = "First Name must be less than 25 characters long")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Last Name must be at least 3 characters long")]
        [MaxLength(30, ErrorMessage = "Last Name must be less than 25 characters long")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(7, ErrorMessage = "Password must be at least 7 characters long")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password), ErrorMessage = "Passwords don't match")]
        public string PasswordConf { get; set; }
    }
}
