using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.Models
{
    public class Book
    {
        [Key]
        public  int id { get; set; }
        public string name { get; set; }    
        public string description { get; set; }
        public string category { get; set; }
        public double price { get; set; } 

        public IList<Book_User> bookUser { get; set;} 
        
    }
}
