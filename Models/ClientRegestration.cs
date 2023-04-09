using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.Models
{
    public class ClientRegestration
    {
        [Required(ErrorMessage ="user name is required")]
        [RegularExpression(@"^[a-zA-Z]+$" , ErrorMessage = "user name is characters only")]
        public string name { get; set; }

        [Required(ErrorMessage = "user email is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" , ErrorMessage = "email is not valid")]
        public string email { get; set; }

        [Required(ErrorMessage = "user country is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "country name is in valid")]
        public string country { get; set; }

        [Required(ErrorMessage = "user city is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "city name is in valid")]
        public string city { get; set; }

        [Required(ErrorMessage = "user address is required")]

        public string address { get; set; }

        [Required(ErrorMessage = "user phone is required")]
        // [RegularExpression(@"^\d$", ErrorMessage = "mobile number is not valid")]
        public string phone { get; set; }

        [Required(ErrorMessage = "password is required")]
        [MinLength(8 , ErrorMessage = "min lenght is 8 characters")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password" , ErrorMessage = "please check password and confirm password again")]
        [DataType(DataType.Password)]
        public string repeatedPassword { get; set; }
    }
}
