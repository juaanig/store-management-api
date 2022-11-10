using store_management_api.Data.Repository.Interfaces;
using store_management_api.DBcontext;
using store_management_api.Entities;
using store_management_api.Helpers;
using store_management_api.Models;

namespace store_management_api.Data.Repository.implementations
{
    
    public class UsuariosRepository : IUsuarioRepository
    {
        private UsuarioContext _context;

        public UsuariosRepository(UsuarioContext context)
        {
            _context = context;
        }

        public void Add(Usuarios user)
        {
            try
            {
                _context.Usuario.Add(user);
                _context.SaveChanges();


            }
            catch
            {
                throw new Exception();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _context.Usuario.Remove(_context.Usuario.First(x => (x.Id).Equals(id)));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Edit(int id, string newPassword)
        {
            try
            {
                _context.Usuario.First(x => (x.Id).Equals(id)).Id = id;
                _context.Usuario.First(x => (x.Id).Equals(id)).Password = newPassword;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Usuarios> GetAll()
        {
            try
            {
                return _context.Usuario.ToList();
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Usuarios> GetOne(int id)
        {
            try
            {
                return _context.Usuario.Where(x => (x.Id).Equals(id)).ToList();
            }
            catch
            {
                throw new Exception();
            }
        }

        public Usuarios? ValidateUser(AuthenticationRequestBody user)
        {
            var pass = Security.CreateSHA512(user.Password);
            return _context.Usuario.SingleOrDefault(u => u.Email == user.Email && u.Password == Security.CreateSHA512(user.Password));
        }
    }
    
}