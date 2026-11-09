using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University_Cafeteria_Inventory_code_first.Models;

namespace University_Cafeteria_Inventory_code_first.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; }

    }
}
