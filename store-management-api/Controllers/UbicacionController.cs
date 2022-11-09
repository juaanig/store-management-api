using Microsoft.AspNetCore.Mvc;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Models;
using System.Linq;

namespace store_management_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionRepository _ubicacionRepository;


        public UbicacionController(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;

        }



        [HttpGet]
        // CORROBORAR UBICACION

        public IActionResult GetAll()
        {
            try
            {
                List<UbicacionDto> response = new List<UbicacionDto>();
                List<Ubicacion> ubicaciones = _ubicacionRepository.GetAll();
                foreach (var ubic in ubicaciones)
                {
                    response.Add(
                        new UbicacionDto()
                        {
                            NameLocation = ubic.NameLocation,
                            ExpDate = ubic.ExpDate,
                        }
                    );
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [HttpPost]
        [Route("addUbicacion")]

        // CORROBORAR UBICACION

        public IActionResult Add(UbicacionDto dto)
        {
            try
            {
                Ubicacion ubicacion = new Ubicacion()
                {
                    NameLocation = dto.NameLocation,
                    ExpDate = dto.ExpDate,
                };

                _ubicacionRepository.Add(ubicacion);
                return Created("Succesfully created", ubicacion);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        [Route("deleteUbicacion/{id}")]
        
        public IActionResult Delete(int id)
        {
            try
            {
                _ubicacionRepository.Delete(id);
                return Ok("Borrado exitosamente");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editUbicacion/{id}/{nameLocation}/{expDate}")]

        public IActionResult Edit(int id, string nameLocation, bool expDate)
        {
            try
            {
                _ubicacionRepository.Edit(id, nameLocation, expDate);
                return Ok("Editado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}