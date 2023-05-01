using BookStore.Core.Models;

namespace BookStore.Service.Services.Implementations
{
    public class MenuService
    {
        public bool IsAdmin;
        private User[] _users = { new User { UserName = "Admin1", Password = "HecKiminAglinaGelmeyecekBirSey123" } };
        private AuthorService _authorService = new AuthorService();
        private BookService _bookService = new BookService();
        public async Task<bool> Login()
        {
            Console.WriteLine("Enter your username:");
            string UserName = Console.ReadLine().Trim();
            Console.WriteLine("Enter your password:");
            string Password = Console.ReadLine().Trim();
            if (_users.Any(User => User.UserName == UserName && User.Password == Password)) IsAdmin = true;
            else
            {
                Console.WriteLine("Username or password incorrect");
                IsAdmin = false;
            }
            return IsAdmin;
        }
        public MenuService()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string Sentence = "WELCOME TO MY CONSOLE APP PROJECT";
            foreach (char a in Sentence)
            {
                Thread.Sleep(15);
                Console.Write(a);
            }
            Console.WriteLine();
        }
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
                    case "2": Console.WriteLine(await _authorService.UpdateAsync(await GetAuthorIdAsync())); break;
                    case "3": Console.WriteLine(await _authorService.DeleteAsync(await GetAuthorIdAsync())); break;
                    case "4": Console.WriteLine(await _authorService.GetAsync(await GetAuthorIdAsync())); break;
                    case "5": foreach (Author Author in await _authorService.GetAllAsync()) Console.WriteLine(Author); break;
                    case "6": foreach (Book Book in await _authorService.GetAllBooksAsync(await GetAuthorIdAsync())) Console.WriteLine(Book); break;

                    case "7": Console.WriteLine(await _bookService.CreateAsync(await GetAuthorIdAsync())); break;
                    case "8": Console.WriteLine(await _bookService.UpdateAsync(await GetAuthorIdAsync(), await GetBookIdAsync())); break;
                    case "9": Console.WriteLine(await _bookService.DeleteAsync(await GetAuthorIdAsync(), await GetBookIdAsync())); break;
                    case "10": Console.WriteLine(await _bookService.GetAsync(await GetAuthorIdAsync(), await GetBookIdAsync())); break;
                    case "11": await _bookService.ShowAllAsync(); break;
                    default: Console.WriteLine("Choose a valid option:"); break;
                }
                Console.WriteLine(  );
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
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
                Request = Console.ReadLine().Trim();
                Console.Clear();
            }
        }
        public async void ShowMenuForUsers()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("0. Close App");
            Console.WriteLine("1. Show Author By ID");
            Console.WriteLine("2. Show All Authors");
            Console.WriteLine("3. Show BookWriter's books");
            Console.WriteLine("4. Show Book By Author");
            Console.WriteLine("5. Show All Books");
            Console.WriteLine("6. Buy A Book");
            Console.ForegroundColor = ConsoleColor.White;
            string Request = Console.ReadLine().Trim();
            Console.Clear();
            while (Request != "0")
            {
                switch (Request)
                {
                    case "1": Console.WriteLine(await _authorService.GetAsync(await GetAuthorIdAsync())); break;
                    case "2": foreach (Author Author in await _authorService.GetAllAsync()) Console.WriteLine(Author); break;
                    case "3": foreach (Book Book in await _authorService.GetAllBooksAsync(await GetAuthorIdAsync())) Console.WriteLine(Book); break;
                    case "4": Console.WriteLine(await _bookService.GetAsync(await GetAuthorIdAsync(), await GetBookIdAsync())); break;
                    case "5": await _bookService.ShowAllAsync(); break;
                    case "6": Console.WriteLine(await _bookService.BuyBook(await GetAuthorIdAsync(), await GetBookIdAsync())); break;
                    default: Console.WriteLine("Choose a valid option:"); break;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("0. Close App");
                Console.WriteLine("1. Show Author By ID");
                Console.WriteLine("2. Show All Authors");
                Console.WriteLine("3. Show BookWriter's books");
                Console.WriteLine("4. Show Book By Author");
                Console.WriteLine("5. Show All Books");
                Console.WriteLine("6. Buy A Book");
                Console.ForegroundColor = ConsoleColor.White;
                Request = Console.ReadLine().Trim();
                Console.Clear();

            }
        }
        private async Task<int> GetAuthorIdAsync()
        {
            Console.WriteLine("Enter the ID of the author:");
            int.TryParse(Console.ReadLine().Trim(), out int AuthorId);
            while (AuthorId == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID is not in the correct format. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the ID again:");
                int.TryParse(Console.ReadLine().Trim(), out AuthorId);
            }
            Console.WriteLine();
            return AuthorId;
        }
        private async Task<int> GetBookIdAsync()
        {
            Console.WriteLine("Enter the ID of the book:");
            int.TryParse(Console.ReadLine().Trim(), out int BookId);
            while (BookId == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ID is not in the correct format. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter the ID again:");
            }
            Console.WriteLine();
            return BookId;
        }
    }  
}