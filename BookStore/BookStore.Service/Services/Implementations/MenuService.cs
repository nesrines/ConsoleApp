using BookStore.Core.Models;
using System.Reflection.Metadata;

namespace BookStore.Service.Services.Implementations
{
    public class MenuService
    {
        private AuthorService _authorService = new AuthorService();
        private BookService _bookService = new BookService();
        public async void ShowMenuForAdmins()
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("0. Close App");
            Console.WriteLine("1. Create Author");
            Console.WriteLine("2. Update Author");
            Console.WriteLine("3. Delete Author");
            Console.WriteLine("4. Show Author By ID");
            Console.WriteLine("5. Show All Authors");
            Console.WriteLine("6. Show BookWriter's books");
            Console.WriteLine("7. Create Book");
            Console.WriteLine("8. Update Book");
            Console.WriteLine("9. Delete Book");
            Console.WriteLine("10. Show Book By Author");
            Console.WriteLine("11. Show All Books");
            Console.ForegroundColor = ConsoleColor.White;
            string Request = Console.ReadLine().Trim();
            Console.Clear();

            while(Request != "0")
            {
                switch(Request)
                {
                    case "1": Console.WriteLine(await _authorService.CreateAsync()); break;
                    case "2": Console.WriteLine(await _authorService.UpdateAsync(await GetIdAsync())); break;
                    case "3": Console.WriteLine(await _authorService.DeleteAsync(await GetIdAsync())); break;
                    case "4": Console.WriteLine(await _authorService.GetAsync(await GetIdAsync())); break;
                    case "5":
                        foreach (Author Author in await _authorService.GetAllAsync())
                        { Console.WriteLine(Author); }
                        break;

                    case "6":
                        foreach (Book Book in await _authorService.GetAllBooksAsync(await GetIdAsync()))
                        { Console.WriteLine(Book); }
                        break;

                    case "7":

                        break;

                    case "8":

                        break;

                    case "9":

                        break;

                    case "10":

                        break;

                    case "11":

                        break;

                    default: Console.WriteLine("Choose a valid option:"); break;
                }
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
                Console.WriteLine("0. Close App");
                Console.WriteLine("1. Create Author");
                Console.WriteLine("2. Update Author");
                Console.WriteLine("3. Delete Author");
                Console.WriteLine("5. Show Author By ID");
                Console.WriteLine("5. Show All Authors");
                Console.WriteLine("6. Show BookWriter's books");
                Console.WriteLine("7. Create Book");
                Console.WriteLine("8. Update Book");
                Console.WriteLine("9. Delete Book");
                Console.WriteLine("10. Show Book By Author");
                Console.WriteLine("11. Show All Books");
                Console.ForegroundColor = ConsoleColor.White;
                Request = Console.ReadLine().Trim();
                Console.Clear();
            }
        }
        private async Task<int> GetIdAsync()
        {
            Console.WriteLine("Enter the ID of the author:");
            int.TryParse(Console.ReadLine().Trim(), out int Id);
            while (Id == 0)
            {
                Console.WriteLine("ID is not in the correct format. Enter the ID again:");
                int.TryParse(Console.ReadLine().Trim(), out Id);
            }
            Console.WriteLine();
            return Id;
        }
    }  
}