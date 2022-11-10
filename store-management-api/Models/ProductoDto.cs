namespace store_management_api.Models
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpDate { get; set; }

        public int UbicacionId { get; set; }
    }
}
