using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.Repositories
{
    internal class BookRepository : AbstractRepository<Book>
    {
        public BookRepository() : base() { }

        public override void Add(List<Book> newBooks)
        {
            using (_db)
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
            using (_db)
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
            using (_db)
            {
                // Получение всех существующих книг в БД
                return _db.Books.ToList();
            }
        }

        public Book ReadOne(int id)
        {
            using (_db)
            {
                // Конкретную книгу по Id
                var book = _db.Books.Find(id);

                return book;
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db)
            {
                // Изменение книги по её Id
                var book = _db.Books.Find(id);

                switch (nameColumn)
                {
                    case nameof(book.Name):
                        book.Name = value;
                        break;
                    case nameof(book.ReleaseDate):
                        var date = DateTime.Parse(value);
                        book.ReleaseDate = date;
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
