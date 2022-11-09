using Microsoft.AspNetCore.Mvc;
using store_management_api.Data.Repository.Interfaces;
using store_management_api.Entities;
using store_management_api.Models;

namespace store_management_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionRepository _ubicacionRepository;


        public UbicacionController(IUbicacionRepository ubicacionRepository)
        {
            _ubicacionRepository = ubicacionRepository;

        }


        //[HttpPost]
        //public IActionResult AddUser(AddUsuarioRequest dto)
        //{
        //    try
        //    {
        //        Usuarios user = new Usuarios()
        //        {
        //            Email = dto.Email,
        //            Name = dto.Name,
        //            LastName = dto.LastName,
        //            Role = dto.Role,
        //            Password = dto.Password,
        //        };

        //        _usuarioRepository.Add(user);
        //        return Created("Succesfully created", user);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
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

    }
}