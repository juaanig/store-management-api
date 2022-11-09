using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Helpers;
using store_management_api.Models;

namespace store_management_api.Data.Repository.implementations
{
    public class UsuarioRepository
    {
        public class UsuariosRepository : IUsuarioRepository
        {

            public static List<Usuarios> fakeUsers = new List<Usuarios>()
        {
            new Usuarios()
            {
                Id = 0,
                Name = "Francisco",
                LastName = "Mulé",
                Email = "fm@gmail.com",
                Role = "Deposito",
            }
        };

            public void Add(Usuarios user)
            {
                try
                {
                    fakeUsers.Add(user);

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
                    fakeUsers.Remove(fakeUsers.First(x => (x.Id).Equals(id)));
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
                    fakeUsers.First(x => (x.Id).Equals(id)).Id = id;
                    fakeUsers.First(x => (x.Id).Equals(id)).Password = newPassword;
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
                    return fakeUsers.ToList();

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
                    return fakeUsers.Where(x => (x.Id).Equals(id)).ToList();

                }
                catch
                {
                    throw new Exception();
                }
            }

            public Usuarios? ValidateUser(AuthenticationRequestBody user)
            {
                var pass = Security.CreateSHA512(user.Password);
                return fakeUsers.SingleOrDefault(u => u.Email == user.Email && u.Password == Security.CreateSHA512(user.Password));
            }
        }
    }
}
