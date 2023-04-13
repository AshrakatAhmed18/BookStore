using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Repo.CartRepo
{
    public interface ICartRepo
    {
        public List<CartVM> GetAll();
        public bool Delete(int id);
        public bool AddToCart(int id, int quantity);

    }
}
