using BooksEccommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace BooksEccommerce.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<User> _userManager ,SignInManager<User> _signInManager , RoleManager<IdentityRole> _roleManager) {

            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (ClientRegestration clientModel)
        {
            if (ModelState.IsValid)
            {
                User client = new User();
                client.UserName = clientModel.name;
                client.Email= clientModel.email;
                client.country = clientModel.country;
                client.city = clientModel.city;
                client.address = clientModel.address;
                client.PhoneNumber = clientModel.phone;
                client.PasswordHash = clientModel.password;

                IdentityResult identity = await userManager.CreateAsync(client , clientModel.password);

                if (identity.Succeeded)
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Client";
                    IdentityResult result = await roleManager.CreateAsync(role);

                    await userManager.AddToRoleAsync(client, "Client");
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim("books shop" , "client"));
                    await signInManager.SignInWithClaimsAsync(client, false,claims);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in identity.Errors)
                        ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User userModel = await userManager.FindByEmailAsync(loginViewModel.email);
                if (userModel != null)
                {
                    //found username
                    await signInManager.PasswordSignInAsync(userModel, loginViewModel.password, true, false);
                    if (await userManager.IsInRoleAsync(userModel, "Admin"))
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    return RedirectToAction("Index" , "Home");
                }
                else if (loginViewModel.email == "admin@admin.com" && loginViewModel.password == "jtrAZ525987@35")
                {
                    User client = new User();
                    client.UserName = "admin";
                    client.Email = loginViewModel.email;
                    client.PasswordHash = loginViewModel.password;
                    client.country = "Egypt";
                    client.city = "Cairo";
                    client.address = "Naser City";
                    client.PhoneNumber = "0155555555555";

                    IdentityResult identity = await userManager.CreateAsync(client, loginViewModel.password);

                    if (identity.Succeeded)
                    {
                        IdentityRole role = new IdentityRole();
                        role.Name = "Admin";
                        IdentityResult result = await roleManager.CreateAsync(role);

                        await userManager.AddToRoleAsync(client, "Admin");
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("books shop", "Admin"));
                        await signInManager.SignInWithClaimsAsync(client, false, claims);
                        return RedirectToAction("Index", "Product");

                    }
                    else
                    {
                        foreach (var item in identity.Errors)
                            ModelState.AddModelError("", item.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Wrong");
                }

            }
            return View();
        }

        public async Task<IActionResult> SignOut ()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
