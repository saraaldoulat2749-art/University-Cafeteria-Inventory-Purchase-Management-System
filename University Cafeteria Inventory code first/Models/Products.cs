using System;
using System.Collections.Generic;
using University_Cafeteria_Inventory_code_first.Models;

namespace University_Cafeteria_Inventory_code_first.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? NameP { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItems>();

    public virtual Supplier? Supplier { get; set; }
}