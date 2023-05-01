using BookStore.Service.Services.Implementations;
MenuService MenuService = new MenuService();
Console.WriteLine("1. As admin");
Console.WriteLine("2. As user");
MenuService.ShowMenuForAdmins();
//MenuService.ShowMenuForUsers();