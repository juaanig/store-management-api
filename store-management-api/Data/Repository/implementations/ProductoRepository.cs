using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;

namespace store_management_api.Data.implementations
{
    public class ProdRepository
    {
        public class ProductoRepository : IProductoRepository
        {
            public static List<Producto> products = new List<Producto>()
            {
                new Producto("Honda cbr " ,10,59600,new DateTime(2100,5,12), new DateTime(2020,5,12)),
                new Producto("Yamaha r1 " ,5,60000 ,new DateTime(2100,5,12), new DateTime(2023,5,12)),
                new Producto("Bmw s1000rr" ,2,75000 ,new DateTime(2100,5,12),new DateTime(2021,5,12))
            };

            public void Add(Producto producto)
            {
                try
                {
                    products.Add(producto);
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
                    products.Remove(products.First(x => (x.Id).Equals(id)));
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
                    products.First(x => (x.Id).Equals(id)).Name = productName;
                    products.First(x => (x.Id).Equals(id)).ExpDate = expirationDate;
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
                    return products.ToList();
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
                    return products.Where(x => (x.Id).Equals(id)).ToList();
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}
