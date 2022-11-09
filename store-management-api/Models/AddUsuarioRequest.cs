using System.ComponentModel.DataAnnotations;

namespace store_management_api.Models
{
    public class AddUsuarioRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        [MinLength(10)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
