using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Models;
using static store_management_api.Data.implementations.ProdRepository;

namespace store_management_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductoController : ControllerBase
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            List<Producto> productos = _productoRepository.GetAll();
            List<ProductoDto> response = new List<ProductoDto>();
            foreach(var producto in productos)
            {
                response.Add(
                    new ProductoDto()
                    {
                        Name = producto.Name,
                        Quantity = producto.Quantity,
                        Price = producto.Price
                    }
                );
            }
            
            return Ok(response);

        }
    }
}