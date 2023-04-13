using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksEccommerce.Models
{
    public class Book
    {
        [Key]
        public  int id { get; set; }

        public string name { get; set; }
       
        public string description { get; set; }
        [ForeignKey("categoryId")]
        public int categoryId { get; set; }

        public double price { get; set; }
  
		public string? image { get; set; }
		public IList<Book_User> bookUser { get; set;} 
        public virtual Category category { get; set; }

	}
}
