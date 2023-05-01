using BookStore.Core.Models;
using BookStore.Core.Repositories.Books;
using BookStore.Data.Repositories.Authors;

namespace BookStore.Data.Repositories.Books
{
    public class BookRepository : Repository<Book>, IBookRepository
    {

    }
}