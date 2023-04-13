using BooksEccommerce.Repo.CartRepo;
using BooksEccommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BooksEccommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepo cartRepo;

        public CartController(ICartRepo cartRepo)
        {
            this.cartRepo = cartRepo;
        }
        public IActionResult Cart()
        {
            List<CartVM> cart = cartRepo.GetAll();
            return View(cart);
        }
        public IActionResult Delete(int id)
        {
            bool res= cartRepo.Delete(id);
            return Json(res);
        }

        public IActionResult AddToCart(int id,int quantity) {

            bool res = cartRepo.AddToCart(id,quantity);
            return Json(res);

        }






    }
}
