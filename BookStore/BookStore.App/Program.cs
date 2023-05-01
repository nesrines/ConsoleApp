using BookStore.Service.Services.Implementations;
MenuService MenuService = new MenuService();
Console.WriteLine("1. Login as Admin");
Console.WriteLine("2. Login as User");
string Request = Console.ReadLine().Trim();
if (Request == "1")
{
    bool Result = await MenuService.Login();
    while(!Result)
    {
        Result = await MenuService.Login();

        if (!Result)
        {
            Console.WriteLine("2. Login as User");
            Request = Console.ReadLine().Trim();
            if (Request == "2") Result = true;
        }
    }
}
if (MenuService.IsAdmin) MenuService.ShowMenuForAdmins();
else MenuService.ShowMenuForUsers();