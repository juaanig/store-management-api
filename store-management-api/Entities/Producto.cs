using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace store_management_api.Entities
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]           /*DECORADOR AFECTA A ID */
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime ExpDate { get; set; }
        public DateTime EntryDate { get; set; }
        [ForeignKey("UbicacionId")]
        public Ubicacion Ubicaciones { get; set; }
        public int UbicacionId { get; set; }

        public Producto(string name, int quantity, int price, DateTime expDate, DateTime entryDate)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            ExpDate = expDate;
            EntryDate = entryDate;
        }
        public Producto() { }

    }
}
