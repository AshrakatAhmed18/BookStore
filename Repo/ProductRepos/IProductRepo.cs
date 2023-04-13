using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Repo.ProductRepos
{
	public interface IProductRepo
	{
		public List<ProductVM> GetAll();
		public ProductVM GetById(int id);

		public void Add(ProductVM book);
		public void Update(ProductVM book);
		public void Delete(int id);
		public List<ProductVM> GetAllByCategoryId(int? id);

	}
}
