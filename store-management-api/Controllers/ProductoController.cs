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
        private readonly IUbicacionRepository _ubicacionRepository;

        public ProductoController(IProductoRepository productoRepository, IUbicacionRepository ubicacionRepository)
        {
            _productoRepository = productoRepository;
            _ubicacionRepository = ubicacionRepository;
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
                        Id = producto.Id,
                        Name = producto.Name,
                        Quantity = producto.Quantity,
                        Price = producto.Price,
                        UbicacionId = producto.UbicacionId,
                        EntryDate= producto.EntryDate,
                        ExpDate= producto.ExpDate,
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
                    Name =dto.Name,
                    Quantity=dto.Quantity,  
                    Price=dto.Price,
                    EntryDate=dto.EntryDate,
                    ExpDate=dto.ExpDate,
                    Ubicaciones = _ubicacionRepository.GetOne(dto.UbicacionId)[0],
                };

                validateQuantity(producto);
                _productoRepository.Add(producto);
                return Created("Succesfully created", producto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
        public IActionResult Edit(int id, string productName)
        {
            try
            {
                _productoRepository.Edit(id, productName);
                return Ok("Editado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public void validateQuantity(Producto producto)
        {
            
            if(producto.Quantity <= 0)
            {
                throw new Exception("La cantidad tiene que mayor a cero");
            }

        }

    }
}