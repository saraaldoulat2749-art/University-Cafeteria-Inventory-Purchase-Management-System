using System;
using System.Collections.Generic;
using University_Cafeteria_Inventory_code_first.Models;

namespace University_Cafeteria_Inventory_code_first.Models;

public partial class PurchaseOrders
{
    public int Id { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? Statuss { get; set; }

    public int? SupplierId { get; set; }

    public virtual ICollection<PurchaseOrderItems> PurchaseOrderItems { get; set; } = new List<PurchaseOrderItems>();

    public virtual Supplier? Supplier { get; set; }
}