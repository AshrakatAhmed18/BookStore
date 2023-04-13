using BooksEccommerce.Models;
using BooksEccommerce.ViewModels;
using System.Security.Claims;

namespace BooksEccommerce.Repo.CartRepo
{
    public class CartRepo:ICartRepo
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly BooksDB dB;

        public CartRepo(IHttpContextAccessor httpContext , BooksDB dB)
        {
            this.httpContext = httpContext;
            this.dB = dB;
        }
        public List<CartVM> GetAll()
        {
            var userId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return dB.booksUsers.Where(b=>b.userId==userId).Select(b=> new CartVM
            {
                borrowProcess=b.borrowProcess,
                bookId=b.bookId,
                bookName=b.book.name,
                qyantity=b.qyantity,
                Price=b.book.price,
                bookImg=b.book.image
            }).ToList();
        }
        public bool Delete(int id)
        {
            Book_User book = dB.booksUsers.FirstOrDefault(b => b.borrowProcess == id);
            dB.booksUsers.Remove(book);
            if (dB.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool AddToCart(int id, int quantity)
        {
            var userId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chek = dB.booksUsers.Where(x => x.userId == userId && x.bookId == id).FirstOrDefault();
            if (chek!=null)
            {
                if (quantity>0)
                {
                    chek.qyantity = quantity;
                }
                else
                {
                    chek.qyantity += 1;

                }
            }
            else
            {
                Book_User book_User = new Book_User()
                {
                    userId = userId,
                    bookId = id,
                    qyantity = 1
                };
                dB.booksUsers.Add(book_User);
            }
            
            
            if (dB.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }




    }
}
