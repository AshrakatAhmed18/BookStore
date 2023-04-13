using BooksEccommerce.Models;
using BooksEccommerce.Repo.ProductRepos;
using BooksEccommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BooksEccommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IProductRepo productRepo;

		public HomeController(ILogger<HomeController> logger,IProductRepo productRepo)
        {
            _logger = logger;
			this.productRepo = productRepo;
		}

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin , Client")]
        public IActionResult About()
        {
			List<ProductVM> books = productRepo.GetAll();
			return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}