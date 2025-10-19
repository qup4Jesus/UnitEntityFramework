
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    /// <summary>
    /// Данный класс предназначен для работы непосредственно с БД для сущности Book
    /// </summary>
    internal class BookRepository : AbstractRepository<Book>
    {
        public override void Add(List<Book> newBooks)
        {
            using (_db = new MyAppContext())
            {
                foreach (var book in newBooks)
                {
                    // Добавление одной книги, для добавление нескольких
                    // книг используем AddRange(element1, ... ,element13);
                    _db.Books.Add(book);
                }

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db = new MyAppContext())
            {
                // Удаление конкретного пользователя по Id
                var book = _db.Books.Find(id);

                // Удаление одной книги для удаления нескольких
                // книг используем RemoveRange(element1, ... ,element97);
                _db.Books.Remove(book);

                _db.SaveChanges();
            }
        }

        public override List<Book> ReadAll()
        {
            using (_db = new MyAppContext())
            {
                // Получение всех существующих книг в БД
                return _db.Books.ToList();
            }
        }

        public override Book ReadOne(int id)
        {
            using (_db = new MyAppContext())
            {
                // Получение конкретной книги по Id
                var book = _db.Books.Find(id);

                return book;
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db = new MyAppContext())
            {
                // Изменение книги по её Id
                var book = _db.Books.Find(id);

                switch (nameColumn)
                {
                    // Изменение названия книги
                    case nameof(book.Name):
                        book.Name = value;
                        break;
                    // Изменение даты релиза
                    case nameof(book.ReleaseDate):
                        var date = DateOnly.Parse(value);
                        book.ReleaseDate = date;
                        break;
                    // При не соответствии Error
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
