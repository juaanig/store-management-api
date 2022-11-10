using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Models;
using System.Linq;

namespace store_management_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionRepository _ubicacionRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public UbicacionController(IUbicacionRepository ubicacionRepository,IUsuarioRepository usuarioRepository)
        {
            _ubicacionRepository = ubicacionRepository;
            _usuarioRepository = usuarioRepository;
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
                            Id = ubic.Id,
                            UsuarioId = ubic.UsuarioId,
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
        public IActionResult Add(UbicacionDto dto)
        {

            try
            {
                Ubicacion ubicacion = new Ubicacion()
                {
                    NameLocation = dto.NameLocation,
                    ExpDate = dto.ExpDate,
                    UsuarioId = dto.UsuarioId,
                    Usuario = _usuarioRepository.GetOne(dto.UsuarioId)[0],
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
        [Route("deleteUbicacion/")]
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
        [Route("editUbicacion/")]
        public IActionResult Edit(int id, string nameLocation, bool expDate)
        {
            try
            {
                _ubicacionRepository.Edit(id, nameLocation, expDate);
                return Ok("Editado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}