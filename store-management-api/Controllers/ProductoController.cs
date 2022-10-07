using Microsoft.AspNetCore.Mvc;
using store_management_api.Entities;
using System.Linq;

namespace store_management_api.Controllers
{
    public class ProductController : ControllerBase
    {
        List<Producto> products = new List<Producto>()
        {
            new Producto("Honda cbr " ,10,59600,new DateTime(2100,5,12), new DateTime(2020,5,12)),
            new Producto("Yamaha r1 " ,5,60000 ,new DateTime(2100,5,12), new DateTime(2023,5,12)),
            new Producto("Bmw s1000rr" ,2,75000 ,new DateTime(2100,5,12),new DateTime(2021,5,12))
        };

        /*
          ########### ENDPOINT PARA ACTUALIZAR (UPDATE) HTTPPUT  ###########
        */

        [HttpGet("[controller]/Lista")]
        public IEnumerable<Producto> Lista()
        {
            return products;
        }



        [HttpDelete("[controller]/Eliminar/{index}")]
        public IEnumerable<Producto> Borrar(int index) 
        {
            this.products.RemoveAt(index);
            return products;

        }


        [HttpPost("[controller]/Crear/{name}/{quantity}/{price}")]
        public IEnumerable<Producto> Crear(string name,int quantity,int price)
        {

            Producto item = new Producto(name, quantity, price, new DateTime(2100, 5, 12), new DateTime(2020, 5, 12));
            this.products.Add(item);    
            return products;
        }
    }
}