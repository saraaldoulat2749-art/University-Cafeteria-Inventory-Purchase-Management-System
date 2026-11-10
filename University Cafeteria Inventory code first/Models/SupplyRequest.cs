
using Microsoft.AspNetCore.Identity;

namespace University_Cafeteria_Inventory_code_first.Models
{
    public class SupplyRequest
    {
        public int Id { get; set; }

        public DateTime RequestDate { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending";

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public ICollection<RequestItem> RequestItems { get; set; } = new List<RequestItem>();
    }
}
