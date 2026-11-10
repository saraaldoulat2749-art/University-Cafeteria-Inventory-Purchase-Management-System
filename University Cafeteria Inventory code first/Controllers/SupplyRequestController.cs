
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using University_Cafeteria_Inventory_code_first.Data;
using University_Cafeteria_Inventory_code_first.Models;

namespace University_Cafeteria_Inventory_code_first.Controllers
{
    [Authorize]
    public class SupplyRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SupplyRequestController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var requests = _context.SupplyRequests.AsQueryable();

            if (!User.IsInRole("Admin") && !User.IsInRole("SuperAdmin"))
            {
                var userId = _userManager.GetUserId(User);
                requests = requests.Where(r => r.UserId == userId);
            }

            return View(requests.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            if (product == null || quantity <= 0)
            {
                return BadRequest();
            }

            var request = new SupplyRequest
            {
                UserId = _userManager.GetUserId(User)!,
                RequestDate = DateTime.Now,
                TotalPrice = Convert.ToDecimal(product.Price) * quantity,
                Status = "Pending"
            };

            request.RequestItems.Add(new RequestItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = Convert.ToDecimal(product.Price)
            });

            _context.SupplyRequests.Add(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            if (!User.IsInRole("Admin") &&
                !User.IsInRole("SuperAdmin") &&
                request.UserId != _userManager.GetUserId(User))
            {
                return Forbid();
            }

            return View(request);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            if (request.UserId != _userManager.GetUserId(User) ||
                request.Status != "Pending")
            {
                return Forbid();
            }

            ViewBag.Products = _context.Products.ToList();

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, int productId, int quantity)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            if (request.UserId != _userManager.GetUserId(User) ||
                request.Status != "Pending")
            {
                return Forbid();
            }

            var product = _context.Products.Find(productId);

            if (product == null || quantity <= 0)
            {
                return BadRequest();
            }

            _context.RequestItems.RemoveRange(request.RequestItems);

            request.TotalPrice = Convert.ToDecimal(product.Price) * quantity;

            request.RequestItems.Add(new RequestItem
            {
                ProductId = productId,
                Quantity = quantity,
                Price = Convert.ToDecimal(product.Price)
            });

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var request = _context.SupplyRequests
                .Include(r => r.RequestItems)
                .FirstOrDefault(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            if (request.UserId != _userManager.GetUserId(User) ||
                request.Status != "Pending")
            {
                return Forbid();
            }

            _context.RequestItems.RemoveRange(request.RequestItems);
            _context.SupplyRequests.Remove(request);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(int id)
        {
            var request = _context.SupplyRequests.Find(id);

            if (request != null && request.Status == "Pending")
            {
                request.Status = "Approved";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reject(int id)
        {
            var request = _context.SupplyRequests.Find(id);

            if (request != null && request.Status == "Pending")
            {
                request.Status = "Rejected";
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
