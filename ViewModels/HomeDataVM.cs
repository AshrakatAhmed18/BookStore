using BooksEccommerce.Models;

namespace BooksEccommerce.ViewModels
{
    public class HomeDataVM
    {
        public List<ProductVM> books { get; set; }
        public List<CategoryVM> categories { get; set; }

    }
}
