using BooksEccommerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksEccommerce.ViewModels
{
    public class CartVM
    {
        public int borrowProcess { get; set; }
        public int qyantity { get; set; }      
        public int  bookId { get; set; }
        public string  bookName { get; set; }
        public string  bookImg { get; set; }

        public double Price { get; set; }    
    }
}
