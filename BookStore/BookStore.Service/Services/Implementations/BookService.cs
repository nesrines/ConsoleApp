using BookStore.Core.Models;
using BookStore.Service.Services.Interfaces;

namespace BookStore.Service.Services.Implementations
{
    public class BookService : IBookService
    {
        public Task<string> CreateAsync(string Title, double Price, double DiscountedPrice)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(int AuthorId, int BookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int AuhtorId, int BookId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateAsync(int AuthorId, int BookId, string Title, double Price, double DiscountedPrice)
        {
            throw new NotImplementedException();
        }
    }
}