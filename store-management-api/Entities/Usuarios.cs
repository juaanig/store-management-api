

namespace store_management_api.Entities
{
    public class Usuarios
    {
        private int Id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public Usuarios(string name, string lastName, string mail, string password, string role)
        {
            this.name = name;
            this.lastName = lastName;
            this.mail = mail;
            this.role = role;
            this.password = password;
        }

        public List<string> dataUsers()
        {
            List<string> dataUser = new List<string>()
            {
                this.name , this.lastName, this.mail, this.password
            };

            return dataUser ; 
        }
    }

  

}