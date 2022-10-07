namespace store_management_api.Entities
{
    public class Producto
    {
        public string id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public DateTime expDate { get; set; }
        public DateTime entryDate { get; set; }

        public Producto(string name, int quantity, int price, DateTime expDate, DateTime entryDate)
        {
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.expDate = expDate;
            this.entryDate = entryDate;
        }

        public void generatorID() 
        {
            Random r = new Random();
            this.id = this.name + "000" + r.Next(100,1001);
        }

    }
}
