using BookStore.Core.Models;

namespace BookStore.Service.Services.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(string Title, double Price, double DiscountedPrice);
        public Task<string> UpdateAsync(int AuthorId, int BookId, string Title, double Price, double DiscountedPrice);
        public Task<string> DeleteAsync(int AuthorId, int BookId);
        public Task<Book> GetAsync(int AuhtorId, int BookId);
        public Task<List<Book>> GetAllAsync();
    }
}