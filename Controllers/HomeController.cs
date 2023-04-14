using BooksEccommerce.Models;
using BooksEccommerce.Repo.CategoryRepo;
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
        private readonly ICategoryRepo categoryRepo;

        public HomeController(ILogger<HomeController> logger,IProductRepo productRepo,ICategoryRepo categoryRepo)
        {
            _logger = logger;
			this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            HomeDataVM dataVM = new HomeDataVM();
            dataVM.books = productRepo.GetAll();
            dataVM.categories = categoryRepo.GetAll();
            return View(dataVM);
        }

        public IActionResult About()
        {
			List<ProductVM> books = productRepo.GetAll();
			return View(books);
        }
        public IActionResult Products(int? id)
        {
            HomeDataVM dataVM = new HomeDataVM();
            dataVM.books = id == null ? productRepo.GetAll() : productRepo.GetAllByCategoryId(id);
            dataVM.categories = categoryRepo.GetAll();
            return View(dataVM);
        }
        public IActionResult ProductDetails(int id)
        {
            ProductVM product=  productRepo.GetById(id);
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }
    }
}