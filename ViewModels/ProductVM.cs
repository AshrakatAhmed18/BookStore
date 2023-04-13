using BooksEccommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.ViewModels
{
	public class ProductVM
	{

		public int id { get; set; }
        [MaxLength(20)]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The name is characters only")]
        public string name { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The name is characters only")]
        public string description { get; set; }
        [Required]
        public int categoryId { get; set; }
        
        public string categoryName { get; set; }

		public double price { get; set; }
        
		public string image { get; set; }
        public IFormFile imageFile { get; set; }

    }
}
