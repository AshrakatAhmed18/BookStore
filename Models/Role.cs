using System.ComponentModel.DataAnnotations;

namespace BooksEccommerce.Models
{
    public class Role
    {
        [Required(ErrorMessage = "role name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "role name is characters only")]
        public string roleName { get; set; }
    }
}
