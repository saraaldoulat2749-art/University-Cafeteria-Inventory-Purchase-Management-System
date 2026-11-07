namespace University_Cafeteria_Inventory_code_first.Models
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public int categoryId { get; set; }
        public int supplierId { get; set; }
    }
}
