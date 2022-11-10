using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Models;

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

        [HttpPost]
        [Route("addProducto")]
        public IActionResult Add(ProductoDto dto)
        {
            try
            {
                Producto producto = new Producto()
                {
                    Name=dto.Name,
                    Quantity=dto.Quantity,  
                    Price=dto.Price,
                    EntryDate=dto.EntryDate,
                    ExpDate=dto.ExpDate,
                };

                _productoRepository.Add(producto);
                return Created("Succesfully created", producto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteProducto/")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productoRepository.Delete(id);
                return Ok("Borrado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editProducto/")]
        public IActionResult Edit(int id, string productName, DateTime expirationDate)
        {
            try
            {
                _productoRepository.Edit(id, productName, expirationDate);
                return Ok("Editado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}