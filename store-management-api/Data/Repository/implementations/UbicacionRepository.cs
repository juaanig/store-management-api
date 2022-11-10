using store_management_api.Data.Repository.Interfaces;
using store_management_api.DBcontext;
using store_management_api.Entities;

namespace store_management_api.Data.Repository.implementations
{
   
    public class UbicacionRepository : IUbicacionRepository
    {

        private readonly UsuarioContext _context; 

        public UbicacionRepository(UsuarioContext context) { 
            _context = context;
        }

        public void Add(Ubicacion ubicacion)
        {
            try
            {
                _context.Ubicaciones.Add(ubicacion);
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
                _context.Ubicaciones.Remove(_context.Ubicaciones.First(x => (x.Id).Equals(id)));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Edit(int id, string nameLocation, bool expDate)
        {
            try
            {
                _context.Ubicaciones.First(x => (x.Id).Equals(id)).NameLocation = nameLocation;
                _context.Ubicaciones.First(x => (x.Id).Equals(id)).ExpDate = expDate;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Ubicacion> GetAll()
        {
            try
            {
                return _context.Ubicaciones.ToList();
            }
            catch
            {
                throw new Exception();
            };
        }

        public List<Ubicacion> GetOne(int id)
        {
            try
            {
                return _context.Ubicaciones.Where(x => (x.Id).Equals(id)).ToList();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
    
}
