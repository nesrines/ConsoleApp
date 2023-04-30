using BookStore.Core.Models;
using BookStore.Core.Repositories.Books;

namespace BookStore.Data.Repositories.Books
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

    }
}