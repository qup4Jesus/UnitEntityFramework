
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Model.DataTransferObject;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта менеджера (Manager) работающего
    /// с хранилищем (Repository => BookRepository) .
    /// </summary>
    internal class BookManager : IManager<Book, BookUserDto>
    {
        // Данное свойство отвечает за объект (хранилище) который общается с БД.
        private BookRepository _repository;

        // Данное свойство отвечает за объект (фабрику-сборщик) который собирает коллекцию
        // обьектов (Book).
        public IEntityFactory<Book> _factory { get; set; }

        // Данное свойство отвечает за объект (обработчик запросов) которые выполняет 
        // проверки данных для работы с запросами.
        public IRequestHandler<Book, BookUserDto> RequestHandlers { get; set; }

        public BookManager()
        {
            _repository = new BookRepository();
            _factory = new BookFactory();
            RequestHandlers = new BookRequestHandler();
        }

        // Данный метод получет на вход список сгенерированных фабрикой (BookFactory)
        // книг (Book) и проверяет каждого на соответствие данных критериям.
        // В случае несоответствия критериям выходит исключение.
        public void Add(List<Book> books)
        {
            foreach (var book in books)
            {
                if (String.IsNullOrEmpty(book.Name))
                    throw new ArgumentNullException();
                if (!(book.ReleaseDate is DateOnly))
                    throw new ArgumentException();
            }

            _repository.Add(books);
        }

        // Данный метод возвращает список всех записей книг находящихся в БД.
        // В случае пустоты получаемого списка выходит исключение.
        public List<Book> ReadAll()
        {
            var books = _repository.ReadAll();

            if (books is null)
                throw new BookNotFoundException();

            return books;
        }


        // Данный метод возвращает конкретную запись книги по его индентификатору.
        // В случае пустоты получаемой записи выходит исключение.
        public Book ReadOne(int id)
        {
            var book = _repository.ReadOne(id);

            if (book is null)
                throw new BookNotFoundException();

            return book;
        }

        // Данный метод получает на вход данные для изменения записи книги по
        // индентификатору = id, проверяет существование записи, корректности данных 
        // столбец = nameColumn , значение = value. В случае несоответсвия данных 
        // требования выходит ошибка.
        public void Update(int id, string nameColumn, string value)
        {
            var book = _repository.ReadOne(id);

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

            _repository.Update(id, nameColumn, value);
        }

        // Данный метод удаляет конкретную запись книги по индентификатору. В случае
        // пустоты записи выходит исклюение.
        public void Delete(int id)
        {
            var book = _repository.ReadOne(id);

            if (book is null)
                throw new BookNotFoundException();

            _repository.Delete(id);
        }
    }
}
