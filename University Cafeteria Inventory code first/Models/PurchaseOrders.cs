namespace University_Cafeteria_Inventory_code_first.Models
{
    public class PurchaseOrders
    {
        public int id { get; set; }
        public string status { get; set; }
        public int SupplierId { get; set; }
        public DateTime orderDate { get; set; }
    }
}
