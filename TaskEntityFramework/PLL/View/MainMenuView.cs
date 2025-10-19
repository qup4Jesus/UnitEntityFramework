
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    /// <summary>
    /// Данный класс отвечат за вывод в консоль данных. Главное меню.
    /// </summary>
    internal class MainMenuView
    {
        // Данные свойства отвечают за работу с данными для каждой кокретной таблицы.
        private BookManager _books;
        private UserManager _users;
        private DescriptionBookManager _description;
        private AuthorManager _author;

        public MainMenuView(
            BookManager books, 
            UserManager users, 
            DescriptionBookManager descriptionBook, 
            AuthorManager author)
        {
            _books = books;
            _users = users;
            _description = descriptionBook;
            _author = author;
        }

        // Главного меню
        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                        "Добро пожаловать в нашу библиотеку!\n" +
                        "Выберите таблицу для работы с ней: \n" +
                        "1 - Users\n" +
                        "2 - Books\n" +
                        "3 - DescriptionBook\n" +
                        "4 - Author");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        new ChoiceTableView<User, User>(_users).Show();
                        break;
                    case "2":
                        new ChoiceTableView<Book, BookUserDto>(_books).Show();
                        break;
                    case "3":
                        new ChoiceTableView<DescriptionBook, DescriptionBookAuthorDto>(_description).Show();
                        break;
                    case "4":
                        new ChoiceTableView<Author, Author>(_author).Show();
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
