using BookStore.Core.Models;
using BookStore.Data.Repositories.Authors;
using BookStore.Service.Services.Interfaces;
namespace BookStore.Service.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private static readonly AuthorRepository _authorRepository = new AuthorRepository();
        public async Task<string> CreateAsync()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the first name of the author:");
            string FirstName = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(FirstName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Name is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the first name of the author again:");
                FirstName = Console.ReadLine().Trim();
            }


            Console.WriteLine("Enter the last name of the author:");
            string LastName = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(LastName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Name is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the last name of the author again:");
                LastName = Console.ReadLine().Trim();
            }

            Console.WriteLine("Enter the age of the author:");
            int.TryParse(Console.ReadLine().Trim(), out int Age);
            while (Age < 13)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Age is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the age of the author again:");
                FirstName = Console.ReadLine().Trim();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Author Author = new Author(FirstName, LastName, Age);
            Author.CreatedDate = DateTime.UtcNow.AddHours(4);
            Author.UpdatedDate = DateTime.UtcNow.AddHours(4);
            await _authorRepository.AddAsync(Author);
            return "Author was created successfully!";
        }
        
        public async Task<string> UpdateAsync(int Id)
        {
            Author Author = await GetAsync(Id);
            if (Author == null) return "";
            Console.WriteLine(Author);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("0. Nothing; 1. First name; 2. Last name; 3. Age;");
            string Request = Console.ReadLine().Trim();
            
            while (Request != "0")
            {
                Console.Clear();
                switch (Request)
                {
                    case "1":
                        Console.WriteLine("Enter the updated first name of the author:");
                        string FirstName = Console.ReadLine().Trim();
                        while (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Name is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated last name of the author again:");
                            FirstName = Console.ReadLine().Trim();
                        }
                        Author.FirstName = FirstName;
                        break;

                    case "2":
                        Console.WriteLine("Enter the updated first name of the author:");
                        string LastName = Console.ReadLine().Trim();
                        while (string.IsNullOrWhiteSpace(LastName))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Name is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated last name of the author again:");
                            LastName = Console.ReadLine().Trim();
                        }
                        Author.LastName = LastName;
                        break;

                    case "3":
                        Console.WriteLine("Enter the updated age of the author:");
                        int.TryParse(Console.ReadLine().Trim(), out int Age);
                        while (Age < 13)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Age is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated age of the author again:");
                            int.TryParse(Console.ReadLine().Trim(), out Age);
                        }
                        Author.Age = Age;
                        break;

                    default:
                        Console.WriteLine("Choose a valid option:");
                        break;
                }
                Console.WriteLine(await GetAsync(Id));
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("What else do you want to change?");
                Console.WriteLine("0. Nothing; 1. First name; 2. Last name; 3. Age");
                Request = Console.ReadLine().Trim();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Author.UpdatedDate = DateTime.UtcNow.AddHours(4);
            return "OK, All Changes Saved!";
        }

        public async Task<string> DeleteAsync(int Id)
        {
            Author Author = await GetAsync(Id);
            if (Author == null) return "";
            Console.WriteLine(Author);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Are you sure you want to delete this author?");
            string answer = Console.ReadLine().Trim();
            if (answer != "YES" && answer != "yes" && answer != "Yes")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Could not delete the author";
            }

            Console.ForegroundColor = ConsoleColor.Green;
            _authorRepository.RemoveAsync(Author);
            return "Author was deleted successfully!";
        }
        
        public async Task<Author> GetAsync(int Id)
        {
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == Id);
            if (Author == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found");
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
                Console.WriteLine("Author not found");
                return null;            
            }
            List<Book> Books = Author.Books;
            if (Books == null)
            {
                Console.WriteLine("No available books");
                return null;
            }
            return Books;
        }
    }
}