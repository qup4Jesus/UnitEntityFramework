
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

        public MainMenuView(ManagerBook books, ManagerUser users)
        {
            _books = books;
            _users = users;
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
                    case "users":
                        goto case "1";
                    case "books":
                        goto case "2";
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
