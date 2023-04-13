using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksEccommerce.Models
{
    public class Book_User
    {
        [Key]
        public int borrowProcess { get; set; }
        public int qyantity { get; set; }

        [ForeignKey("user")]
        public string userId { get; set; }
        public virtual User user { get; set; }


        [ForeignKey("book")]
        public int bookId { get; set; }
        public virtual Book book { get; set; }
    }
}
