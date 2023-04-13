namespace BooksEccommerce.Models
{
	public class Category
	{
        public int id { get; set; }
        public string name { get; set; }
        public List<Book> books { get; set; }
    }
}
