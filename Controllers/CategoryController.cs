using BooksEccommerce.Repo.CategoryRepo;
using BooksEccommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksEccommerce.Controllers
{
    [Authorize(Roles ="Admin,Clinet")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepo categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<CategoryVM> categories = categoryRepo.GetAll();
            return View(categories);
        }

        public IActionResult New()
        {


            return View();
        }
        [HttpPost]
        public IActionResult New(CategoryVM category)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    categoryRepo.Add(category);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }

            return View(category);
        }
        public IActionResult Edit(int id)
        {

            var category = categoryRepo.GetById(id);
            

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(CategoryVM category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryRepo.Update(category);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {

            categoryRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
