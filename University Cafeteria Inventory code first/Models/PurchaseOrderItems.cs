namespace University_Cafeteria_Inventory_code_first.Models
{
    public class PurchaseOrderItems
    {
        public int id { get; set; }
        public int purchaseOrderId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }

        public decimal price { get; set; }
    }
}
