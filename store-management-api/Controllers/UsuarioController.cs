using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using store_management_api.Entities;


namespace store_management_api.Controllers
{
    public class UsuarioController : Controller
    {
        List<Usuarios> users = new List<Usuarios>()
        {
            new Usuarios("Juan" ,"Garnero", "juangarnero@hotmail.com.ar", "jajajajaj12","idolo"),
            new Usuarios("Lucas" ,"Butto", "lbutto@hotmail.com.ar", "jijijijijijij58","master"),
            new Usuarios("Herman" ,"Kraus", "hkraus@hotmail.com.ar", "kkkkkkkk45","powerlifter")
        };


        [HttpGet("[controller]/Lista")]
        public IEnumerable<Usuarios> Lista()
        {
            return users;
        }

        /*
          ########### ENDPOINT PARA ACTUALIZAR (UPDATE) HTTPPUT  ###########
        */

        [HttpDelete("[controller]/Eliminar/{index}")]
        public IEnumerable<Usuarios> Borrar(int index)
        {
            this.users.RemoveAt(index);
            return users;

        }


        [HttpPost("[controller]/Crear/{name}/{lastname}/{email}/{password}/{role}")]
        public IEnumerable<Usuarios> Crear(string name,string lastname,string email,string password,string role)
        {

            Usuarios user = new Usuarios(name, lastname, email, password, role);
            this.users.Add(user);
            return users;
        }


    }
}
