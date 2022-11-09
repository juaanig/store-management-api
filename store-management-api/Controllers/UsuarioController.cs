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
    public class UsuarioController : ControllerBase
    {
        
        private readonly IUsuarioRepository _usuarioRepository;

        
        public UsuarioController(IUsuarioRepository usuarioRepository )
        {
            _usuarioRepository = usuarioRepository;
        }
        
        [HttpPost]
        public IActionResult AddUser(AddUsuarioRequest dto)
        {
            try
            {
                Usuarios user = new Usuarios()
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Role = dto.Role,
                    Password = dto.Password,
                };

                _usuarioRepository.Add(user);
                return Created("Succesfully created", user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<UsuarioResponse> response = new List<UsuarioResponse>();
                List<Usuarios> users = _usuarioRepository.GetAll();
                foreach (var user in users)
                {
                    response.Add(
                        new UsuarioResponse()
                        {
                            Name = user.Name,
                            LastName = user.LastName,
                            Mail = user.Email,
                            Role = user.Role,
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

        [HttpDelete]
        [Route("deleteUsuario/")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Delete(id);
                return Ok("Borrado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("editUsuario/")]
        public IActionResult Edit(int id, string newPassword)
        {
            try
            {
                _usuarioRepository.Edit(id, newPassword);
                return Ok("Editado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
