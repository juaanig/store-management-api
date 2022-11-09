using System.ComponentModel.DataAnnotations;

namespace store_management_api.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
