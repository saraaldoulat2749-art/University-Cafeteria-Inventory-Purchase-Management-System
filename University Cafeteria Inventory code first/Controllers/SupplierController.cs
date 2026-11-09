using Microsoft.AspNetCore.Mvc;
using University_Cafeteria_Inventory_code_first.Data;
using University_Cafeteria_Inventory_code_first.Models;

namespace University_Cafeteria_Inventory_code_first.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.Find(id);

            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            return View(supplier);
        }
    }
}
