using BooksEccommerce.Models;
using BooksEccommerce.Repo.ProductRepos;
using BooksEccommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksEccommerce.Controllers
{
	[Authorize(Roles ="Admin")]
	public class ProductController : Controller
	{
		private readonly IProductRepo productRepo;

		public ProductController(IProductRepo productRepo)
        {
			this.productRepo = productRepo;
		}

        public IActionResult Index()
		{
			List<ProductVM> books = productRepo.GetAll();
			return View(books);
		}

		public IActionResult New()
		{
			
			
			return View();
		}
		[HttpPost]
		public IActionResult New(ProductVM book)
		{
			try
			{
				if (ModelState.IsValid)
				{

					productRepo.Add(book);
					return RedirectToAction("Index");
				}
			}
			catch (Exception ex)
			{
				
			}
			
			return View( book);
		}
        public IActionResult Edit(int id)
        {

            var book = productRepo.GetById(id);
            ProductVM bookVM = new ProductVM();
            bookVM.id = book.id;
            bookVM.name = book.name;
			bookVM.description = book.description;
			bookVM.categoryId = book.categoryId;
			bookVM.image = book.image;
			bookVM.price = book.price;



            return View( bookVM);
        }
        [HttpPost]
        public IActionResult Edit(ProductVM book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productRepo.Update(book);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
              
            }
            return View( book);
        }

		public IActionResult Delete(int id)
		{

			productRepo.Delete(id);
			return RedirectToAction("Index");
		}


	}
}
