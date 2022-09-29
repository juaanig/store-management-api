namespace store_management_api.Entities
{
    public class Producto
    {
        public string id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime expDate { get; set; }
        public DateTime entryDate { get; set; }

        public void generatorID() 
        {
            Random r = new Random();
            this.id = this.name + "000" + r.Next(100,1001);
        }




    }
}
