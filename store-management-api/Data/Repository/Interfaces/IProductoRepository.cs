using store_management_api.Entities;

namespace store_management_api.Data.Repository.Interfaces
{
  
    public interface IProductoRepository
    {
        public List<Producto> GetOne(int id);

        public List<Producto> GetAll();

        public void Add(Producto producto);

        public void Delete(int id);

        public void Edit(int id, string productName, DateTime expirationDate);

    }
    
}
