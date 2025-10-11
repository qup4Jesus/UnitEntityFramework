
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL;
using TaskEntityFramework.PLL.View;

var books = new ManagerBook();
var users = new ManagerUser();
var description = new ManagerDescriptionBook();
var author = new ManagerAuthor();

var start = new MainMenuView(books, users, description, author);

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


