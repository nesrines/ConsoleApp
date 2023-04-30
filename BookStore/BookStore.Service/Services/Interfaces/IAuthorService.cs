using BookStore.Core.Models;
namespace BookStore.Service.Services.Interfaces
{
    public interface IAuthorService
    {
        public Task<string> CreateAsync(string FirstName, string Surname, int Age);
        public Task<string> UpdateAsync(int Id, string FirstName, string Surname, int Age);
        public Task<string> DeleteAsync(int Id);
        public Task<Author> GetAsync(int Id);
        public Task<List<Author>> GetAllAsync();
        public Task<List<Book>> GetAllBooksAsync(int Id);
    }
}