
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL;
using TaskEntityFramework.PLL.View;

var books = new BookManager();
var users = new UserManager();
var description = new DescriptionBookManager();
var author = new AuthorManager();

var menu = new MainMenuView(books, users, description, author);

while (true)
{
    menu.Show();
}