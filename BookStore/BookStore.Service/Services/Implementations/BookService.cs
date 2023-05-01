using BookStore.Core.Models;
using BookStore.Core.Enums;
using BookStore.Data.Repositories.Authors;
using BookStore.Service.Services.Interfaces;
namespace BookStore.Service.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly AuthorRepository _authorRepository = new AuthorRepository();
        public async Task<string> CreateAsync(int AuthorId)
        {
            return "Book was created successfully!";
        }

        public async Task<string> UpdateAsync(int AuthorId, int BookId)
        {
            Book Book = await GetAsync(AuthorId, BookId);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("0. Nothing; 1. Title; 2. Author; 3. Category; 4. InStock; 5. Price; 6. Discounted Price");
            Console.ForegroundColor = ConsoleColor.White;
            string Request = Console.ReadLine().Trim();

            while (Request != "0")
            {
                Console.Clear();

                switch (Request)
                {
                    case "1":
                        Console.WriteLine("Enter the updated title of the book:");
                        string Title = Console.ReadLine().Trim();
                        while (string.IsNullOrWhiteSpace(Title))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Title is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated title of the book again:");
                            Title = Console.ReadLine().Trim();
                        }
                        Book.Title = Title;
                        break;

                    case "2":
                        Console.WriteLine("Enter the updated author's ID:");

                        break;

                    case "3":
                        Console.WriteLine("Enter the updated category of the book:");
                        BookCategory Category = new BookCategory();
                        break;

                    case "4":
                        Console.WriteLine("Enter the updated InStock of the book:");
                        int.TryParse(Console.ReadLine(), out int InStock);
                        while (InStock == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("InStock is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated InStock of the book again:");
                            int.TryParse(Console.ReadLine().Trim(), out InStock);
                        }
                        Book.InStock = InStock;
                        break;

                    case "5":
                        Console.WriteLine("Enter the updated price of the book");
                        double.TryParse(Console.ReadLine().Trim(), out double Price);
                        while (Price == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Price is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated price of the book again:");
                            double.TryParse(Console.ReadLine().Trim(), out Price);
                        }
                        Book.Price = Price;
                        break;

                    case "6":
                        Console.WriteLine("Enter the updated price of the book");
                        double.TryParse(Console.ReadLine().Trim(), out double DiscountedPrice);
                        while (DiscountedPrice == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Price is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated price of the book again:");
                            double.TryParse(Console.ReadLine().Trim(), out DiscountedPrice);
                        }
                        Book.DiscountedPrice = DiscountedPrice;
                        break;

                    default:
                        Console.WriteLine("Choose a valid option:");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("What else do you want to change?");
                Console.WriteLine("0. Nothing; 1. Title; 2. Author; 3. Category; 4. InStock; 5. Price; 6. Discounted Price");
                Console.ForegroundColor = ConsoleColor.White;
                Request = Console.ReadLine().Trim();
            }
            Book.UpdatedDate = DateTime.UtcNow.AddHours(4);
            return "OK, All Changes Saved!";
        }

        public async Task<string> DeleteAsync(int AuthorId, int BookId)
        {
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == AuthorId);
            if (Author == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found");
                return null;
            }
            Book Book = await GetAsync(AuthorId, BookId);
            if (Book == null) return "";
            Console.WriteLine(Book);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Are you sure you want to delete this book?");
            string answer = Console.ReadLine().Trim();
            if (answer != "YES" && answer != "yes" && answer != "Yes")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Could not delete the book";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Author.Books.Remove(Book);
            return "Book was deleted successfully!";
        }

        public async Task<Book> GetAsync(int AuthorId, int BookId)
        {
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == AuthorId);
            if (Author == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found");
                return null;
            }
            Book Book = Author.Books.FirstOrDefault(Book => Book.Id == BookId);
            if (Book == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found");
                return null;
            }
            return Book;
        }

        public async Task GetAllAsync()
        {
            foreach (Author Author in await _authorRepository.GetAllAsync())
            {
                foreach (Book Book in Author.Books)
                {
                    Console.WriteLine(Book);
                }
            }
        }
    }
}