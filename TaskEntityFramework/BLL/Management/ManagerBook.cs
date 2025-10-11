
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

        public void Add(string name, string date)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(date))
                throw new ArgumentNullException();
            if (!DateOnly.TryParse(date, out DateOnly result))
                throw new ArgumentNullException();

            List<Book> newBook = new List<Book> { new Book { Name = name, ReleaseDate = DateTime.Parse(date) } };

            _manager.Add(newBook);
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
