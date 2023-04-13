using AutoMapper;
using BooksEccommerce.Models;
using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Repo.CategoryRepo
{
    public class CategoryRepo :ICategoryRepo
    {
        private readonly IMapper mapper;
        private readonly BooksDB db;

        public CategoryRepo(IMapper mapper, BooksDB db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public List<CategoryVM> GetAll()
        {
            return db.categories.Select(c => new CategoryVM
            {
                id = c.id,
                name = c.name,


            }).ToList();
        }
        public CategoryVM GetById(int id)
        {
            return db.categories.Select(c => new CategoryVM
            {
                id = c.id,
                name = c.name,
             
            }).FirstOrDefault(c => c.id == id);
        }
        public void Add(CategoryVM category)
        {
            
            var data = mapper.Map<Category>(category);

            db.categories.Add(data);
            db.SaveChanges();
        }
        public void Update(CategoryVM category)
        {
           
            var data = mapper.Map<Category>(category);

            db.categories.Update(data);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            CategoryVM category = GetById(id);
            var data = mapper.Map<Category>(category);
            db.categories.Remove(data);
            db.SaveChanges();

        }
    }
}
