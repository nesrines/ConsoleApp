using BookStore.Core.Models;
using BookStore.Core.Enums;
namespace BookStore.Service.Services.Interfaces
{
    public interface IBookService
    {
        public Task<string> CreateAsync(int AuthorId);
        public Task<string> UpdateAsync(int AuthorId, int BookId);
        public Task<string> DeleteAsync(int AuthorId, int BookId);
        public Task<Book> GetAsync(int AuthorId, int BookId);
        public Task ShowAllAsync();
        public Task<string> BuyBook(int AuthorId, int BookId);
    }
}