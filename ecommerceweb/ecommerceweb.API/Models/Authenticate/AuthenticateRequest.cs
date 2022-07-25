using System.ComponentModel.DataAnnotations;

namespace ecommerceweb.API.Models.Authenticate
{
    public partial class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
