using store_management_api.Entities;
using store_management_api.Models;

namespace store_management_api.Data.Repository.Interfaces
{
   
    public interface IUsuarioRepository
    {
        public List<Usuarios> GetOne(int id);

        public List<Usuarios> GetAll();

        public void Add(Usuarios user);

        public void Delete(int id);

        public void Edit(int id, string newPassword);

        public Usuarios? ValidateUser(AuthenticationRequestBody user);
    }
    
}
