using store_management_api.Data.Repository.Interfaces;
using store_management_api.DBcontext;
using store_management_api.Entities;

namespace store_management_api.Data.implementations
{

    public class ProductoRepository : IProductoRepository
    {
        private readonly UsuarioContext _context;

        public ProductoRepository(UsuarioContext context)
        {
            _context = context;
        }
        public void Add(Producto producto)
        {
            try
            {
                _context.Productos.Add(producto);
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
                _context.Productos.Remove(_context.Productos.First(x => (x.Id).Equals(id)));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public void Edit(int id, string productName)
        {
            try
            {
                _context.Productos.First(x => (x.Id).Equals(id)).Name = productName;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Producto> GetAll()
        {
            try
            {
                return _context.Productos.ToList();
            }
            catch
            {
                throw new Exception();
            };
        }

        public List<Producto> GetOne(int id)
        {
            try
            {
                return _context.Productos.Where(x => (x.Id).Equals(id)).ToList();
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}