using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace University_Cafeteria_Inventory_code_first.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoles()
        {
            string[] roles = { "User", "Admin", "SuperAdmin" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            return RedirectToAction("Index");
        }
    }
}