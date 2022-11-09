using store_management_api.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_management_api.Entities
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]               /*DECORADOR AFECTA A ID */

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value); }
        }
        public string Role { get; set; }

        public Usuarios(string name, string lastName, string mail, string password, string role)
        {
            Name = name;
            LastName = lastName;
            Email = mail;
            Role = role;
            Password = password;
        }

        public Usuarios()
        {
        }
    }

  

}