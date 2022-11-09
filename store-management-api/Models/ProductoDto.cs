namespace store_management_api.Models
{
    public class ProductoDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
