using store_management_api.Data.Repository.Interfaces;
using store_management_api.DBcontext;
using store_management_api.Entities;

namespace store_management_api.Data.implementations
{

    public class ProductoRepository : IProductoRepository
    {
        //public static List<Producto> products = new List<Producto>()
        //{
        //    new Producto("Honda cbr " ,10,59600,new DateTime(2100,5,12), new DateTime(2020,5,12)),
        //    new Producto("Yamaha r1 " ,5,60000 ,new DateTime(2100,5,12), new DateTime(2023,5,12)),
        //    new Producto("Bmw s1000rr" ,2,75000 ,new DateTime(2100,5,12),new DateTime(2021,5,12))
        //};

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

        public void Edit(int id, string productName, DateTime expirationDate)
        {
            try
            {
                _context.Productos.First(x => (x.Id).Equals(id)).Name = productName;
                _context.Productos.First(x => (x.Id).Equals(id)).ExpDate = expirationDate;
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