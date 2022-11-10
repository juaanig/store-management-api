using store_management_api.Entities;

namespace store_management_api.Models
{
    public class UbicacionDto
    {
        public int Id { get; set; }
        public string NameLocation { get; set; }
        public bool ExpDate { get; set; }
        public int UsuarioId { get; set; }

    }
}
