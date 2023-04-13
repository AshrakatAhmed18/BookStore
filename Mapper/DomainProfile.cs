using AutoMapper;
using BooksEccommerce.Models;
using BooksEccommerce.ViewModels;

namespace BooksEccommerce.Mapper
{
	public class DomainProfile : Profile
	{
        public DomainProfile()
        {
            CreateMap<Book, ProductVM>();
            CreateMap<ProductVM, Book>();
            CreateMap<CategoryVM, Category>();
            CreateMap<Category, CategoryVM>();
        }
    }
}
