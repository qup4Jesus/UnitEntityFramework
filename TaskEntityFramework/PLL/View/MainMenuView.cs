
using Microsoft.EntityFrameworkCore.Query.Internal;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class MainMenuView
    {
        private ManagerBook _books;
        private ManagerUser _users;
        private ManagerDescriptionBook _description;
        private ManagerAuthor _author;

        public MainMenuView(ManagerBook books, ManagerUser users, ManagerDescriptionBook descriptionBook, ManagerAuthor author)
        {
            _books = books;
            _users = users;
            _description = descriptionBook;
            _author = author;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine(
                        "Добро пожаловать в нашу библиотеку!\n" +
                        "Выберите таблицу для работы с ней: \n" +
                        "1 - Users\n" +
                        "2 - Books");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        new ChoiceTableView<User>(_users).Show();
                        break;
                    case "2":
                        new ChoiceTableView<Book>(_books).Show();
                        break;
                    case "3":
                        new ChoiceTableView<DescriptionBook>(_description).Show();
                        break;
                    case "4":
                        new ChoiceTableView<Author>(_author).Show();
                        break;
                    case "users":
                        goto case "1";
                    case "books":
                        goto case "2";
                    case "description":
                        goto case "3";
                    case "author":
                        goto case "4";
                    default:
                        AlertMessages.Show("Выбран не верный пункт меню!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
