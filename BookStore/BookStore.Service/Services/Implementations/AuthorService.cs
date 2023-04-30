using BookStore.Core.Models;
using BookStore.Data.Repositories.Authors;
using BookStore.Service.Services.Interfaces;
namespace BookStore.Service.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private static readonly AuthorRepository _authorRepository = new AuthorRepository();
        public async Task<string> CreateAsync(string FirstName, string LastName, int Age)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(FirstName))
                return "Add a valid first name:";
            if (string.IsNullOrWhiteSpace(LastName))
                return "Add a valid last name:";
            if (Age < 5)
                return "Add a valid age:";

            Console.ForegroundColor = ConsoleColor.Green;
            Author Author = new Author(FirstName, LastName, Age);
            await _authorRepository.AddAsync(Author);
            return "Author was created successfully.";
        }
        
        public async Task<string> UpdateAsync(int Id, string FirstName, string LastName, int Age)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == Id);
            if (Author == null)
                return "Author not found";
            if (string.IsNullOrWhiteSpace(FirstName))
                return "Add a valid first name:";
            if (string.IsNullOrWhiteSpace(LastName))
                return "Add a valid last name:";
            if (Age < 5)
                return "Add a valid age:";
            
            Console.ForegroundColor = ConsoleColor.Green;
            Author.FirstName = FirstName;
            Author.LastName = LastName;
            Author.Age = Age;
            return "Author was updated successfully.";
        }
        
        public async Task<string> DeleteAsync(int Id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == Id);
            if (Author == null)
                return "Author not found";

            Console.ForegroundColor = ConsoleColor.Green;
            _authorRepository.RemoveAsync(Author);
            return "Author was deleted successfully.";
        }
        
        public async Task<Author> GetAsync(int Id)
        {
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == Id);
            if (Author == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found.");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            return Author;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            List<Author> Authors = await _authorRepository.GetAllAsync();
            if (Authors == null)
            {
                Console.WriteLine("No available authors");
                return null;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            return Authors;
        }
        
        public async Task<List<Book>> GetAllBooksAsync(int Id)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == Id);
            if (Author == null)
            {
                Console.WriteLine("Author not found.");
                return null;            
            }
            List<Book> Books = Author.Books;
            if (Books == null)
            {
                Console.WriteLine("No available books");
                return null;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            return Books;
        }
    }
}