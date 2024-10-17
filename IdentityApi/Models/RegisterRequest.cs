using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Models
{
    public class RegisterRequest
    {
        [EmailAddress]
        [Required]
        [MinLength(10)]
        public string Email { get; set; }
        [Required]
        [Length(6,20)]
        public string Password { get; set; }
    }
}
