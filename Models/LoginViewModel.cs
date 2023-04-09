using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "user email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "email is not valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MinLength(8, ErrorMessage = "min lenght is 8 characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        
    }
}
