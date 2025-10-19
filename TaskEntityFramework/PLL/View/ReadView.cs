
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    /// <summary>
    /// Данный класс отвечает за ввывод в консоль данных. Меню чтения записей.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table для универсальной
    /// работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DateTransferObject для 
    /// универсальной работы </typeparam>
    internal class ReadView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        private IManager<TEntity, TDto> _manager;

        public ReadView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        // Меню чтения записей.
        public void Show()
        {
            while (true)
            {
                Console.Clear();

                SuccessMessages.Show("Просмотр записей");

                Console.WriteLine("Выберите нужный пункт меню : \n" +
                    "1 - Показать все записи\n" +
                    "2 - Показать конкретную запись по ID\n" +
                    "3 - Показать записи по условию\n" +
                    "4 - Показать записи по сложному условию\n" +
                    "5 - Показать первую запись в таблице\n" +
                    "6 - Показать объединенные таблицы\n" +
                    "7 - Показать сумму ID (???)\n" +
                    "<-- back <<<");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        ShowAllRecords();
                        break;
                    case "2":
                        ShowRecordById();
                        break;
                    case "3":
                        ShowRecordByWhere();
                        break;
                    case "4":
                        ShowRecordByTaskWhere();
                        break;
                    case "5":
                        ShowRecordFirst();
                        break;
                    case "6":
                        ShowRecordJoin();
                        break;
                    case "7":
                        ShowRecordSum();
                        break;
                    case "back":
                        return;
                    default:
                        AlertMessages.Show("Введено не корректное значение!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        // Метод для вывода всех существующих записей конкретной таблицы.
        private void ShowAllRecords()
        {
            List<TEntity> listElem = _manager.ReadAll();

            foreach (TEntity item in listElem)
            {
                if (item is User user)
                {
                    Console.WriteLine(
                        $"Имя пользователя: {user.Name}\n" +
                        $"Email пользователя: {user.Email}\n");
                }
                else if (item is Book book)
                {
                    Console.WriteLine(
                        $"Название книги: {book.Name}\n" +
                        $"Дата выхода: {book.ReleaseDate}\n" +
                        $"ID Описания книги: {book.DescriptionBookId}");
                }
                else if (item is DescriptionBook descriptionBook)
                {
                    Console.WriteLine(
                        $"Описание книги: {descriptionBook.Description}\n" +
                        $"Жанр: {descriptionBook.Genre}\n" +
                        $"ID автора: {descriptionBook.AuthorId}");
                }
                else if (item is Author author)
                {
                    Console.WriteLine(
                        $"Название книги: {author.Name}\n" +
                        $"Год рождения: {author.YearBirth}\n" +
                        $"Гож смерти: {author.YearDeath}");
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        // Метод для вывода конкретной записи по индентификатору в таблице.
        private void ShowRecordById()
        {
            Console.Write("Введите id: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                TEntity record = _manager.ReadOne(id);

                if (record is User user)
                {
                    Console.WriteLine(
                        $"Имя пользователя: {user.Name}\n" +
                        $"Email пользователя: {user.Email}\n");
                }
                else if (record is Book book)
                {
                    Console.WriteLine(
                        $"Название книги: {book.Name}\n" +
                        $"Дата выхода: {book.ReleaseDate}\n" +
                        $"ID Описания книги: {book.DescriptionBookId}");
                }
                else if (record is DescriptionBook descriptionBook)
                {
                    Console.WriteLine(
                        $"Описание книги: {descriptionBook.Description}\n" +
                        $"Жанр: {descriptionBook.Genre}\n" +
                        $"ID автора: {descriptionBook.AuthorId}");
                }
                else if (record is Author author)
                {
                    Console.WriteLine(
                        $"Название книги: {author.Name}\n" +
                        $"Год рождения: {author.YearBirth}\n" +
                        $"Гож смерти: {author.YearDeath}");
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        // Метод для показа записи в зависимости от условия.
        private void ShowRecordByWhere()
        {
            Console.Write("Введите столбец по которому нужно произвести поиск: ");
            string nameColumn = Console.ReadLine().ToLower();

            Console.Write("Введите значение по которому нужно произвести поиск: ");
            string whereValue = Console.ReadLine().ToLower();

            List<TEntity> record = _manager.RequestHandlers.Find(whereValue, nameColumn);

            if (record is List<User> users)
            {
                foreach (User user in users)
                {
                    Console.WriteLine(
                    $"Имя пользователя: {user.Name}\n" +
                    $"Email пользователя: {user.Email}\n");
                }
            }
            else if (record is List<Book> books)
            {
                foreach (Book book in books)
                {
                    Console.WriteLine(
                    $"Название книги: {book.Name}\n" +
                    $"Дата выхода: {book.ReleaseDate}\n" +
                    $"ID Описания книги: {book.DescriptionBookId}");
                }
            }
            else if (record is List<DescriptionBook> descriptionBooks)
            {
                foreach (DescriptionBook descriptionBook in descriptionBooks)
                {
                    Console.WriteLine(
                    $"Описание книги: {descriptionBook.Description}\n" +
                    $"Жанр: {descriptionBook.Genre}\n" +
                    $"ID автора: {descriptionBook.AuthorId}");
                }
            }
            else if (record is List<Author> authors)
            {
                foreach (Author author in authors)
                {
                    Console.WriteLine(
                    $"Название книги: {author.Name}\n" +
                    $"Год рождения: {author.YearBirth}\n" +
                    $"Гож смерти: {author.YearDeath}");
                }
            }
            else
            {
                throw new Exception();
            }
        }

        // Метод для показа первой записи в таблицу.
        private void ShowRecordFirst()
        {
            switch (_manager.RequestHandlers.FindFirst())
            {
                case User user:

                    Console.WriteLine(
                        $"Имя пользователя: {user.Name}\n" +
                        $"Email пользователя: {user.Email}\n");

                    break;
                case Book book:

                    Console.WriteLine(
                        $"Название книги: {book.Name}\n" +
                        $"Дата выхода: {book.ReleaseDate}\n" +
                        $"ID Описания книги: {book.DescriptionBookId}");

                    break;
                case DescriptionBook descriptionBook:

                    Console.WriteLine(
                        $"Описание книги: {descriptionBook.Description}\n" +
                        $"Жанр: {descriptionBook.Genre}\n" +
                        $"ID автора: {descriptionBook.AuthorId}");

                    break;
                case Author author:

                    Console.WriteLine(
                        $"Название книги: {author.Name}\n" +
                        $"Год рождения: {author.YearBirth}\n" +
                        $"Гож смерти: {author.YearDeath}");

                    break;
                default:
                    throw new Exception();
            }
        }

        // Метод для показа обьеденения таблиц.
        private void ShowRecordJoin()
        {
            switch (_manager.RequestHandlers.Join())
            {
                case List<BookDescriptionBookDto> bookDescriptionBooks:

                    foreach (var bookDescriptionBook in bookDescriptionBooks)
                    {
                        Console.WriteLine(
                            $"Книга (id) : {bookDescriptionBook.BookId}\n" +
                            $"Название книги : {bookDescriptionBook.BookName}\n" +
                            $"Дата выхода: {bookDescriptionBook.ReleaseDate}\n" +
                            $"Описание книги (id) : {bookDescriptionBook.DescriptionBookId}\n" +
                            $"Описание : {bookDescriptionBook.Description}\n" +
                            $"Жанр : {bookDescriptionBook.Genre}\n" +
                            $"Пользователь (id) : {bookDescriptionBook.UserId}\n" +
                            $"Автор (id) : {bookDescriptionBook.AuthorId}");
                    }

                    break;
                case List<BookUserDto> bookUsers:

                    foreach (var bookUser in bookUsers)
                    {
                        Console.WriteLine(
                        $"Книга (id) : {bookUser.BookId}\n" +
                        $"Название книги : {bookUser.BookName}\n" +
                        $"Дата выхода: {bookUser.ReleaseDate}\n" +
                        $"Пользователь (id) : {bookUser.UserId}\n" +
                        $"Имя пользователя : {bookUser.UserName}\n" +
                        $"Email пользователя : {bookUser.Email}\n" +
                        $"Описание книги (id) : {bookUser.DescriptionBookId}");
                    }

                    break;
                case List<DescriptionBookAuthorDto> descriptionBookAuthors:

                    foreach (var descriptionBookAuthor in descriptionBookAuthors)
                    {
                        Console.WriteLine(
                        $"Описание книги (id) : {descriptionBookAuthor.DescriptionBookId}\n" +
                        $"Описание : {descriptionBookAuthor.Description}\n" +
                        $"Жанр : {descriptionBookAuthor.Genre}\n" +
                        $"Автор (id) {descriptionBookAuthor.AuthorId}\n" +
                        $"Имя автора : {descriptionBookAuthor.Name}\n" +
                        $"Дата рождения : {descriptionBookAuthor.YearBirth}" +
                        $"Дата смерти : {descriptionBookAuthor.YearDeath}");
                    }

                    break;
                default:
                    throw new Exception();
            }
        }

        // Метод для показа суммы целочисленых (int) столбцов
        private void ShowRecordSum()
        {
            Console.WriteLine($"Сумма id-шников : {_manager.RequestHandlers.Sum()}");
        }

        // Метод для показа сложных условий.
        private void ShowRecordByTaskWhere()
        {
            switch (_manager.RequestHandlers.FindFirst())
            {
                case User user:
                    AlertMessages.Show("❌❌❌ Пока не придумано ❌❌❌");
                    break;
                case Book book:

                    Console.Clear();

                    Console.WriteLine(
                        "Выберете один из запросов:\n" +
                        "1 - Получить список книг определённого жанра и вышедшими между определенными годами\n" +
                        "2 - Получить количество книг определенного автора в библиотеке\n" +
                        "3 - Получить количество книг определенного жанра в библиотеке\n" +
                        "4 - Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке\n" +
                        "5 - Получить булевый флаг о том, есть ли определенная книга на руках у пользователя\n" +
                        "6 - Получить количество книг на руках у пользователя\n" +
                        "7 - Получение последней вышедшей книги\n" +
                        "8 - Получение списка всех книг, отсортированного в алфавитном порядке по названию\n" +
                        "9 - Получение списка всех книг, отсортированного в порядке убывания года их выхода\n" +
                        "<-- back <<<\n");

                    Console.WriteLine("Введите номер команды :");
                    string command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "1":

                            int numberCommand = int.Parse(command);

                            Console.Write("Введите жанр : ");
                            string genre = Console.ReadLine();

                            Console.WriteLine("Введите временной промежуток: ");
                            Console.Write("c - ");
                            string fromDate = Console.ReadLine();

                            Console.Write("до - ");
                            string toDate = Console.ReadLine();

                            List<Book> bookList = new BookManager().RequestHandlers.FindTask(numberCommand, genre, fromDate, toDate);

                            foreach (var element in bookList)
                            {
                                Console.WriteLine(
                                $"Название книги: {element.Name}\n" +
                                $"Дата выхода: {element.ReleaseDate}\n" +
                                $"ID Описания книги: {element.DescriptionBookId}");
                            }

                            break;
                        case "2":

                            numberCommand = int.Parse(command);

                            Console.Write("Введите имя автора : ");
                            string authorName = Console.ReadLine();

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, authorName, "", "");

                            Console.WriteLine(bookList.Count);

                            break;
                        case "3":

                            numberCommand = int.Parse(command);

                            Console.Write("Введите жанр : ");
                            genre = Console.ReadLine();

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, genre, "", "");

                            Console.WriteLine(bookList.Count);

                            break;
                        case "4":

                            numberCommand = int.Parse(command);

                            Console.Write("Введите имя автора : ");
                            authorName = Console.ReadLine();

                            Console.Write("Введите название книги : ");
                            string bookName = Console.ReadLine();

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, bookName, authorName, "");

                            if (bookList.Count == 0)
                                Console.WriteLine(false);
                            else
                                Console.WriteLine(true);

                                break;
                        case "5":

                            numberCommand = int.Parse(command);

                            Console.Write("Введите пользователя (id) : ");
                            string userId = Console.ReadLine();

                            Console.Write("Введите название книги : ");
                            bookName = Console.ReadLine();

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, bookName, userId, "");

                            if (bookList.Count == 0)
                                Console.WriteLine(false);
                            else
                                Console.WriteLine(true);

                            break;
                        case "6":

                            numberCommand = int.Parse(command);

                            Console.Write("Введите пользователя (id) : ");
                            userId = Console.ReadLine();

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, userId, "", "");

                            Console.WriteLine($"Количество книг на руках у пользователя: {bookList.Count()}");

                            break;
                        case "7":

                            numberCommand = int.Parse(command);

                            Console.WriteLine("Последняя вышедшая книга : ");

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, "", "", "");

                            foreach (var element in bookList)
                            {
                                Console.WriteLine(
                                $"Название книги: {element.Name}\n" +
                                $"Дата выхода: {element.ReleaseDate}\n" +
                                $"ID Описания книги: {element.DescriptionBookId}");
                            }

                            break;
                        case "8":

                            numberCommand = int.Parse(command);

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, "", "", "");

                            foreach (var element in bookList)
                            {
                                Console.WriteLine(
                                $"Название книги: {element.Name}\n" +
                                $"Дата выхода: {element.ReleaseDate}\n" +
                                $"ID Описания книги: {element.DescriptionBookId}");
                            }

                            break;
                        case "9":

                            numberCommand = int.Parse(command);

                            bookList = new BookManager().RequestHandlers.FindTask(numberCommand, "", "", "");

                            foreach (var element in bookList)
                            {
                                Console.WriteLine(
                                $"Название книги: {element.Name}\n" +
                                $"Дата выхода: {element.ReleaseDate}\n" +
                                $"ID Описания книги: {element.DescriptionBookId}");
                            }

                            break;
                        case "back":
                            return;
                        default:
                            AlertMessages.Show("Выбран не верный пункт меню!");
                            break;
                    }

                    break;
                case DescriptionBook descriptionBook:
                    AlertMessages.Show("❌❌❌ Пока не придумано ❌❌❌");
                    break;
                case Author author:
                    AlertMessages.Show("❌❌❌ Пока не придумано ❌❌❌");
                    break;
            }
        }
    }
}