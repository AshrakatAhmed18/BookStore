using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Repo.CategoryRepo
{
    public interface ICategoryRepo
    {
        public List<CategoryVM> GetAll();
        public CategoryVM GetById(int id);

        public void Add(CategoryVM book);
        public void Update(CategoryVM book);
        public void Delete(int id);
    }
}
