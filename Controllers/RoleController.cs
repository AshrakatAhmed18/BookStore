using BooksEccommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BooksEccommerce.Controllers
{
    [Authorize(Roles = "Admin")]

    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager; 
        public RoleController(RoleManager<IdentityRole> _roleManager) 
        {
            roleManager= _roleManager;
        }
        public IActionResult Index()
        {

            return View(roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult AddRole()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(Role role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole newRole = new IdentityRole();
                newRole.Name = role.roleName;
                IdentityResult result = await roleManager.CreateAsync(newRole);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var roles = roleManager.Roles.ToList();
            IdentityRole role = roles.Where(r => r.Id == id).FirstOrDefault();
            await roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
    }
}
