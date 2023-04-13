using BooksEccommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BooksEccommerce.Controllers
{

    [Authorize(Roles="Admin")]
    public class PrivlliagesController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;


        public PrivlliagesController(UserManager<User> _userManager , SignInManager<User> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager= _signInManager;
        }
        public IActionResult Index()
        {
            IEnumerable<User> users = userManager.Users.ToList();
            ViewBag.userManager = userManager;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            // GetClaimsAsync retunrs the list of user Claims
            var userClaims = await userManager.GetClaimsAsync(user);
            // GetRolesAsync returns the list of user Roles
            var userRoles = string.Join("", await userManager.GetRolesAsync(user));

            EditUserViewModel model = new EditUserViewModel
            {
                userId = user.Id,
                userName = user.UserName,
                email = user.Email,
                role = userRoles
            };

            ViewBag.roles = roleManager.Roles.ToList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] string id , EditUserViewModel editUserViewModel)
        {
            ViewBag.roles = roleManager.Roles.ToList();

            User user = await userManager.FindByIdAsync(id);

            await userManager.RemoveFromRoleAsync(user , string.Join("", await userManager.GetRolesAsync(user)));
            await userManager.AddToRoleAsync(user, editUserViewModel.role);


            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete([FromRoute] string id )
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> addUser()
        {
            ViewBag.roles = roleManager.Roles.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addUser(ClientRegestration userModel , string userRole)
        {
            ViewBag.roles = roleManager.Roles.ToList();

            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = userModel.name;
                user.Email = userModel.email;
                user.country = userModel.country;
                user.city = userModel.city;
                user.address = userModel.address;
                user.PhoneNumber = userModel.phone;
                user.PasswordHash = userModel.password;

                IdentityResult identity = await userManager.CreateAsync(user, userModel.password);

                if (identity.Succeeded)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = userRole;
                    IdentityResult result = await roleManager.CreateAsync(role);

                    await userManager.AddToRoleAsync(user, userRole);
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("books shop", userRole));
                    await signInManager.SignInWithClaimsAsync(user, false, claims);
                    return RedirectToAction("Index", "Privlliages");
                }
                else
                {
                    foreach (var item in identity.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

      
    }
}
