using BooksEccommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.ViewModels
{
    public class CategoryVM
    {
        public int id { get; set; }
        [MaxLength(20)]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The name is characters only")]
        public string name { get; set; }
        public List<Book> books { get; set; }
    }
}
