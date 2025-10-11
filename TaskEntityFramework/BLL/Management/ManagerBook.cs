
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class ManagerBook : IManager<Book>
    {
        private BookRepository _manager;

        public ManagerBook(BookRepository repository)
        {
            _manager = repository;
        }

        public void Add(List<Book> books)
        {
            foreach (var book in books)
            {
                if (String.IsNullOrEmpty(book.Name))
                    throw new ArgumentNullException();
                if (!(book.ReleaseDate is DateTime))
                    throw new ArgumentNullException();
            }

            _manager.Add(books);
        }

        public List<Book> ReadAll()
        {
            var books = _manager.ReadAll();

            if (books.Count == 0)
                throw new ArgumentNullException();

            return books;
        }

        public Book ReadOne(int id)
        {
            var book = _manager.ReadOne(id);

            if (book == null)
                throw new ArgumentNullException();

            return book;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.Name))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.ReleaseDate))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            if (nameColumn == nameof(book.ReleaseDate))
                if (!DateOnly.TryParse(value, out DateOnly result))
                    throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }

        public void Delete(int id)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }
    }
}
