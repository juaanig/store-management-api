using Microsoft.AspNetCore.Mvc;
using store_management_api.Entities;

namespace store_management_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UbicacionController : ControllerBase
    {
        List<Ubicacion> zones = new List<Ubicacion>()
        {
            new Ubicacion("zona de enlatados",50000),
            new Ubicacion("zona de frio",10000)
        };


        /*
            ########### ENDPOINT PARA ACTUALIZAR (UPDATE) HTTPPUT  ###########
        */

        [HttpGet("[controller]/Lista")]
        public IEnumerable<Ubicacion> Lista()
        {
            return zones;
        }


        [HttpDelete("[controller]/Eliminar/{index}")]
        public IEnumerable<Ubicacion> Borrar(int index)
        {
            this.zones.RemoveAt(index);
            return zones;

        }


        [HttpPost("[controller]/Crear/{nameLocation}/{capacity}")]
        public IEnumerable<Ubicacion> Crear(string nameLocation, int capacity)
        {

            Ubicacion zone = new Ubicacion(nameLocation, capacity);
            this.zones.Add(zone);
            return zones;
        }

    }
}