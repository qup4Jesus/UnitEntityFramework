
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Repositories;
using TaskEntityFramework.PLL.View;

var books = new ManagerBook(new BookRepository());
var users = new ManagerUser(new UserRepository());

var start = new MainMenuView(books, users);

while (true)
{
    try
    {
        start.Show();
    }
    catch (Exception)
    {

    }
}

