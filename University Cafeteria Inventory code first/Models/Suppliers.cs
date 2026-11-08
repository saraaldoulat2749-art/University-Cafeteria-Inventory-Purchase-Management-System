using System;
using System.Collections.Generic;

namespace University_Cafeteria_Inventory_code_first.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string? NameS { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<PurchaseOrders> PurchaseOrders { get; set; } = new List<PurchaseOrders>();
}