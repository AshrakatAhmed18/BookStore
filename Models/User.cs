using Microsoft.AspNetCore.Identity;

namespace BooksEccommerce.Models
{
    public class User : IdentityUser
    {
        public string country { get; set; }
        public string city { get; set; }
        public string address { get; set; }

        public IList<Book_User> bookUser { get; set; }

    }
}
