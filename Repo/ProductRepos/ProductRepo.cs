using AutoMapper;
using BooksEccommerce.Helper;
using BooksEccommerce.Models;
using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Repo.ProductRepos
{
	public class ProductRepo : IProductRepo
	{
		private readonly IMapper mapper;
		BooksDB db;
        public ProductRepo(IMapper mapper, BooksDB db)
        {
				this.mapper = mapper;
			    this.db = db;
        }

		public List<ProductVM> GetAll()
		{
			return db.Books.Select(b => new ProductVM
			{
				id = b.id,
				name = b.name,
				description = b.description,
				categoryId = b.categoryId,
				categoryName=b.category.name,
				price = b.price,
				image = b.image


			}).ToList();
		}
        public List<ProductVM> GetAllByCategoryId(int? id)
        {
            return db.Books.Where(b=> b.categoryId==id).Select(b => new ProductVM
            {
                id = b.id,
                name = b.name,
                description = b.description,
                categoryId = b.categoryId,
                categoryName = b.category.name,
                price = b.price,
                image = b.image


            }).ToList();
        }
        public ProductVM GetById(int id)
		{
			return db.Books.Select(b => new ProductVM
			{
				id = b.id,
				name = b.name,
				description = b.description,
				categoryId = b.categoryId,
                categoryName = b.category.name,

                price = b.price,
				image = b.image
			}).FirstOrDefault(b=>b.id==id);
		}
		public  void Add(ProductVM book)
		{
			book.image =  SaveFile.SaveFilee(book.imageFile,FilePath.Images);
			var data = mapper.Map<Book>(book);

			db.Books.Add(data);
			db.SaveChanges();
		}
		public  void Update(ProductVM book)
		{
			book.image = book.imageFile == null ? book.image :  SaveFile.SaveFilee(book.imageFile, FilePath.Images);
			var data = mapper.Map<Book>(book);

			db.Books.Update(data);
			db.SaveChanges();
		}
		public void Delete(int id)
		{
			ProductVM book = GetById(id);
			var data = mapper.Map<Book>(book);
			db.Books.Remove(data);
			db.SaveChanges();

		}



	}

	
}
