
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class ReadView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        private IManager<TEntity, TDto> _manager;

        public ReadView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        public void Show()
        {
            while (true)
            {
                SuccessMessages.Show("Просмотр записей");

                Console.WriteLine("Выберите показ пользователей : \n" +
                    "1 - Показать все записи\n" +
                    "2 - Показать конкретную запись по ID\n" +
                    "3 - Показать записи по условию\n" +
                    "4 - Показать первую запись в таблице\n" +
                    "5 - Показать объединенные таблицы\n" +
                    "6 - Показать сумму ID (???)");

                switch (Console.ReadLine())
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
                        ShowRecordFirst();
                        break;
                    case "5":
                        ShowRecordJoin();
                        break;
                    case "6":
                        ShowRecordSum();
                        break;
                    default:
                        AlertMessages.Show("Введено не корректное значение!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }

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

        private void ShowRecordByWhere()
        {
            Console.Write("Введите столбец по которому нужно произвести поиск: ");
            string nameColumn = Console.ReadLine();

            Console.Write("Введите значение по которому нужно произвести поиск: ");
            string whereValue = Console.ReadLine();

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

        private void ShowRecordSum()
        {
            Console.WriteLine($"Сумма id-шников : {_manager.RequestHandlers.Sum()}");
        }
    }
}