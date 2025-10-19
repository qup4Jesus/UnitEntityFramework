
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;

namespace TaskEntityFramework.DAL.SQLRequests
{
    /// <summary>
    /// Данный класс предназначен для выполнения запрососв к БД (сущность Books).
    /// </summary>
    internal class BookRequest : Requests<Book, BookUserDto>
    {
        public override List<Book> Find(int whereValue)
        {
            // Выполняем запрос по поиску книг у которых Id = whereValue.
            using (_db = new MyAppContext())
                return _db.Books.Where(u => u.Id == whereValue).ToList();
        }

        public override List<Book> Find(string whereValue, string nameColumn)
        {
            // Выполняем запрос по поиску книг, где столбец равен nameColumn, 
            // а искомое значение равно whereValue.
            using (_db = new MyAppContext())
                switch (nameColumn.ToLower())
                {
                    // По столбцу "Name".
                    case "name":
                        return _db.Books.Where(b => b.Name == whereValue).ToList();
                    // По столбцу "ReleaseDate".
                    case "releasedate":
                        return _db.Books.Where(b => b.ReleaseDate == DateOnly.Parse(whereValue)).ToList();
                    // По столбцу "UserId".
                    case "userid":
                        return _db.Books.Where(b => b.UserId == int.Parse(whereValue)).ToList();
                    // По столбцу "UserName".
                    case "username":
                        return _db.Books.Where(b => b.User.Name == whereValue).ToList();
                    // По столбцу "UserEmail".
                    case "useremail":
                        return _db.Books.Where(b => b.User.Email == whereValue).ToList();
                    // По столбцу "DescriptionId".
                    case "descriptionid":
                        return _db.Books.Where(b => b.DescriptionBook.Id == int.Parse(whereValue)).ToList();
                    // По столбцу "Description".
                    case "description":
                        return _db.Books.Where(b => b.DescriptionBook.Description == whereValue).ToList();
                    // По столбцу "Genre".
                    case "genre":
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValue).ToList();
                    // По столбцу "AuthorId".
                    case "authorid":
                        return _db.Books.Where(b => b.DescriptionBook.AuthorId == int.Parse(whereValue)).ToList();
                    // По столбцу "AuthorName".
                    case "authorname":
                        return _db.Books.Where(b => b.DescriptionBook.Author.Name == whereValue).ToList();
                    // По столбцу "AuthoryearBirth".
                    case "authoryearbirth":
                        return _db.Books.Where(b => b.DescriptionBook.Author.YearBirth == DateOnly.Parse(whereValue)).ToList();
                    // По столбцу "AuthoryearDeath".
                    case "authoryeardeath":
                        return _db.Books.Where(b => b.DescriptionBook.Author.YearDeath == DateOnly.Parse(whereValue)).ToList();
                    // Иначе вернется null.
                    default:
                        return null;
                }
        }

        public List<Book> TaskFind(int command, string whereValueFirst, string whereValueSecond, string whereValueTree)
        {
            // Данный метод предназначен для сложных запросов конкретезированный на
            // работу с сущностью Book и реализующий работу конкретных задач для заданий
            // модуля 25.5.4 .
            using (_db = new MyAppContext())
                switch (command)
                {
                    // Выполняется запрос на получение списка книг определенного
                    // жанра и вышедших между определенными годами. Сначала выбирается жанр
                    // книги = whereValueFirst, а затем диапазон определяется значениями (начало)
                    // whereValueSecond (конец) whereValueTree, все значения удовлетворяющие
                    // условиям возвращаются.
                    case 1:
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValueFirst && b.ReleaseDate >= DateOnly.Parse(whereValueSecond) && b.ReleaseDate <= DateOnly.Parse(whereValueTree)).ToList();
                    
                    // Выполняется запрос на получение списка книг определенного автора, где
                    // имя автора = whereValueFirst.
                    case 2: 
                        return _db.Books.Where(b => b.DescriptionBook.Author.Name == whereValueFirst).ToList();

                    // Выполняется запрос на получение списка книг определенного жанра, где 
                    // жанр = whereValueFirst.
                    case 3:
                        return _db.Books.Where(b => b.DescriptionBook.Genre == whereValueFirst).ToList();

                    // Выполняется запрос на получение списка книг определенного автора и с
                    // определенным названием, где название книги = whereValueFirst, автор
                    // книги = whereValueSecond.
                    case 4:
                        return _db.Books.Where(b => b.Name == whereValueFirst && b.DescriptionBook.Author.Name == whereValueSecond).ToList();
                    
                    // Выполняется запрос на получение списка книг с определенным названием
                    // и с определенным id пользователя, где название книги = whereValueFirst,
                    // id пользователя = whereValueSecond.
                    case 5:
                        return _db.Books.Where(b => b.Name == whereValueFirst && b.UserId == int.Parse(whereValueSecond)).ToList();
                    
                    // Выполняется запрос на получение списка книг с id пользователя =
                    // whereValueFirst.
                    case 6:
                        return _db.Books.Where(b => b.UserId == int.Parse(whereValueFirst)).ToList();

                    // Выполняется запрос на получение книги с самым поздним годом публикации.
                    case 7:
                        return new List<Book> { _db.Books.OrderByDescending(b => b.ReleaseDate).FirstOrDefault() };
                    
                    // Выполняется запрос на получение списка книг отсортированных по названию
                    // книги.
                    case 8:
                        return _db.Books.OrderBy(b => b.Name).ToList();

                    // Выполняется запрос на получение списка книг отсортированных по годам
                    // (по убыванию).
                    case 9:
                        return _db.Books.OrderByDescending(b => b.ReleaseDate.Year).ToList();

                    // Иной случай возвращает null.
                    default:
                        return null;
                }
        }

        public override Book FindFirst()
        {
            // Выполняем запрос на получение книги находящейся первой в таблице.
            using (_db = new MyAppContext())
                return _db.Books.First();
        }
        
        public override List<BookUserDto> Join()
        {
            // Выполняем запрос на получение списка обьединения (Join) таблиц Книга (Book) и
            // Пользователь (User), возвращаем все взаимосвязанные значения.
            using (_db = new MyAppContext())
                return _db.Books
                .Join(_db.Users,
                    b => b.UserId,
                    u => u.Id,
                    (b, u) => new BookUserDto
                    {
                        BookId = b.Id,
                        BookName = b.Name,
                        ReleaseDate = b.ReleaseDate,
                        UserId = u.Id,
                        UserName = u.Name,
                        Email = u.Email,
                        DescriptionBookId = b.DescriptionBookId
                    }).ToList();
        }

        new public List<BookDescriptionBookDto> Join(string joinTable)
        {
            // Дополнительный запрос на получение списка обьединения (Join) таблиц Книга (Book) и
            // Опсиание Книги (DescriprionBook), возвращаем все взаимосвязанные значения.
            using (_db = new MyAppContext())
                return _db.Books
                .Join(_db.DescriptionBooks,
                    b => b.DescriptionBookId,
                    db => db.Id,
                    (b, db) => new BookDescriptionBookDto
                    {
                        BookId = b.Id,
                        BookName = b.Name,
                        ReleaseDate = b.ReleaseDate,
                        DescriptionBookId = db.Id,
                        Description = db.Description,
                        Genre = db.Genre,
                        UserId = b.UserId,
                        AuthorId = db.AuthorId
                    }).ToList();
        }

        public override int Sum()
        {
            // Выполняем запрос на получение суммы индентификаторов.
            using (_db = new MyAppContext())
                return _db.Books.Sum(u => u.Id);
        }
    }
}
