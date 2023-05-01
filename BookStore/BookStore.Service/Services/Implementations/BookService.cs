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
            Author Author = await _authorRepository.GetAsync(Author => Author.Id == AuthorId);
            Console.WriteLine("Enter the title of the book:");
            string Title = Console.ReadLine().Trim();
            while (string.IsNullOrWhiteSpace(Title))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Title is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the title again:");
                Title = Console.ReadLine().Trim();
            }

            Console.WriteLine("Choose the category of the book:");
            Console.WriteLine("1. Detective, 2. Fiction, 3. Horror, 4. Romance, 5. Science, 6. Tales");
            int.TryParse(Console.ReadLine().Trim(), out int CategoryIndex);
            while ( CategoryIndex <= 0 || CategoryIndex > 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Category index is not in the correct format. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Choose a valid category:");
                int.TryParse(Console.ReadLine().Trim(), out CategoryIndex);
            }
            BookCategory Category = (BookCategory)CategoryIndex;

            Console.WriteLine("Enter the count of the book:");
            int.TryParse(Console.ReadLine().Trim(), out int Count);
            while (Count < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Count is not in the correct format. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the count again:");
                int.TryParse(Console.ReadLine().Trim(), out Count);
            }

            Console.WriteLine("Enter the price of the book:");
            double.TryParse(Console.ReadLine().Trim(), out double Price);
            while (Price <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Price is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the price again:");
                double.TryParse(Console.ReadLine().Trim(), out Price);
            }

            Console.WriteLine("Enter the discounted price of the book:");
            double.TryParse(Console.ReadLine().Trim(), out double DiscountedPrice);
            while (DiscountedPrice <= 0 || DiscountedPrice > Price)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Discounted price is not valid. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the discounted price again:");
                double.TryParse(Console.ReadLine().Trim(), out DiscountedPrice);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Book Book = new Book(Title, Author, Category, Count, Price, DiscountedPrice);
            Book.CreatedDate = DateTime.UtcNow.AddHours(4);
            Book.UpdatedDate = DateTime.UtcNow.AddHours(4);
            Author.Books.Add(Book);
            return "Book was created successfully!";
        }

        public async Task<string> UpdateAsync(int AuthorId, int BookId)
        {
            Book Book = await GetAsync(AuthorId, BookId);
            if (Book == null) return "";
            Console.WriteLine(Book);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("What do you want to change?");
            Console.WriteLine("0. Nothing, 1. Title, 2. Author, 3. Category, 4. Count, 5. Price, 6. Discounted Price");
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
                            Console.WriteLine("Enter the updated title again:");
                            Title = Console.ReadLine().Trim();
                        }
                        Book.Title = Title;
                        break;

                    case "2":
                        Console.WriteLine("Enter the book's updated author's ID:");
                        int.TryParse(Console.ReadLine(), out int NewAuthorId);
                        while (NewAuthorId < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Author's ID is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the author's ID again:");
                            int.TryParse(Console.ReadLine().Trim(), out NewAuthorId);
                        }
                        Author Author = await _authorRepository.GetAsync(Author => Author.Id == NewAuthorId);
                        if (Author == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Author not found");
                        }
                        Book.Author = Author;
                        break;

                    case "3":
                        Console.WriteLine("Choose the updated category of the book:");
                        Console.WriteLine("1. Detective, 2. Fiction, 3. Horror, 4. Romance, 5. Science, 6. Tales");
                        int.TryParse(Console.ReadLine().Trim(), out int CategoryIndex);
                        while (CategoryIndex <= 0 || CategoryIndex > 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Category index is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Choose a valid category:");
                            int.TryParse(Console.ReadLine().Trim(), out CategoryIndex);
                        }
                        Book.Category = (BookCategory)CategoryIndex;
                        break;

                    case "4":
                        Console.WriteLine("Enter the updated count of the book:");
                        int.TryParse(Console.ReadLine(), out int Count);
                        while (Count < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Count is not in the correct format. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated count again:");
                            int.TryParse(Console.ReadLine().Trim(), out Count);
                        }
                        Book.Count = Count;
                        Book.IsInStock = Book.Count > 0;
                        break;

                    case "5":
                        Console.WriteLine("Enter the updated price of the book");
                        double.TryParse(Console.ReadLine().Trim(), out double Price);
                        while (Price <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Price is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated price again:");
                            double.TryParse(Console.ReadLine().Trim(), out Price);
                        }
                        Book.Price = Price;
                        break;

                    case "6":
                        Console.WriteLine("Enter the updated discounted price of the book");
                        double.TryParse(Console.ReadLine().Trim(), out double DiscountedPrice);
                        while (DiscountedPrice <= 0 || DiscountedPrice > Book.Price)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Discounted price is not valid. ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Enter the updated discounted price again:");
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
                Console.WriteLine("0. Nothing, 1. Title, 2. Author, 3. Category, 4. Count, 5. Price, 6. Discounted Price");
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

        public async Task ShowAllAsync()
        {
            foreach (Author Author in await _authorRepository.GetAllAsync())
            {
                foreach (Book Book in Author.Books)
                {
                    Console.WriteLine(Book);
                }
            }
        }

        public async Task<string> BuyBook(int AuthorId, int BookId)
        {
            Book Book = await GetAsync(AuthorId, BookId);
            if (Book == null)
                return "";
            Console.WriteLine(Book);
            if (!Book.IsInStock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Book is not available";
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Book.Count--;
            Book.IsInStock = Book.Count > 0;
            return "Book was sold successfully!";
        }
    }
}