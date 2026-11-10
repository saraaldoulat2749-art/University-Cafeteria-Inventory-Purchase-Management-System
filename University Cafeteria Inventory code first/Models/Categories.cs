using System;
using System.Collections.Generic;

namespace University_Cafeteria_Inventory_code_first.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? NameC { get; set; }

    public string? DescriptionC { get; set; }

    public virtual ICollection<Product> Products { get; set; } 
}