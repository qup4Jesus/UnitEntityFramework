
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class BookManager : IManager<Book, BookUserDto>
    {
        private BookRepository _manager;
        private BookFactory _factory;
        public IRequestHandler<Book, BookUserDto> RequestHandlers { get; set; }
        public BookManager()
        {
            _manager = new BookRepository();
            _factory = new BookFactory();
            RequestHandlers = new BookRequestHandler();
        }

        public void Add(List<Book> books)
        {
            foreach (var book in books)
            {
                if (String.IsNullOrEmpty(book.Name))
                    throw new ArgumentNullException();
                if (!(book.ReleaseDate is DateOnly))
                    throw new ArgumentException();
            }

            _manager.Add(books);
        }

        public List<Book> ReadAll()
        {
            var books = _manager.ReadAll();

            if (books is null)
                throw new BookNotFoundException();

            return books;
        }

        public Book ReadOne(int id)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new BookNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.Name) && nameColumn != nameof(book.ReleaseDate))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            if (nameColumn == nameof(book.ReleaseDate))
                if (!DateOnly.TryParse(value, out DateOnly result))
                    throw new ArgumentException();

            _manager.Update(id, nameColumn, value);
        }

        public void Delete(int id)
        {
            var book = _manager.ReadOne(id);

            if (book is null)
                throw new BookNotFoundException();

            _manager.Delete(id);
        }

        public IEntityFactory<Book> GetFactory()
        {
            return _factory;
        }
    }
}
