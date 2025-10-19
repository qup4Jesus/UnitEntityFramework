
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
    /// с хранилищем (Repository => DescriptionBookRepository) .
    /// </summary>
    internal class DescriptionBookManager : IManager<DescriptionBook, DescriptionBookAuthorDto>
    {
        // Данное свойство отвечает за объект (хранилище) который общается с БД.
        private DescriptionBookRepository _repository;

        // Данное свойство отвечает за объект (фабрику-сборщик) который собирает коллекцию
        // обьектов (DescriptionBook).
        public IEntityFactory<DescriptionBook> _factory { get; set; }

        // Данное свойство отвечает за объект (обработчик запросов) которые выполняет 
        // проверки данных для работы с запросами.
        public IRequestHandler<DescriptionBook, DescriptionBookAuthorDto> RequestHandlers { get; set; }

        public DescriptionBookManager()
        {
            _repository = new DescriptionBookRepository();
            _factory = new DescriptionBookFactory();
            RequestHandlers = new DescriptionBookRequestHandler();
        }

        // Данный метод получет на вход список сгенерированных фабрикой (DescriprionBookFactory)
        // описания книги (DescriptionBook) и проверяет каждого на соответствие данных критериям.
        // В случае несоответствия критериям выходит исключение.
        public void Add(List<DescriptionBook> listElements)
        {
            foreach (var book in listElements)
            {
                if (String.IsNullOrEmpty(book.Description))
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(book.Genre))
                    throw new ArgumentNullException();
            }

            _repository.Add(listElements);
        }

        // Данный метод удаляет конкретную запись описания книги по индентификатору.
        // В случае пустоты записи выходит исклюение.
        public void Delete(int id)
        {
            var book = _repository.ReadOne(id);

            if (book is null)
                throw new DescriptionBookNotFoundException();

            _repository.Delete(id);
        }

        // Данный метод возвращает список всех записей описания книги находящихся в БД.
        public List<DescriptionBook> ReadAll()
        {
            var books = _repository.ReadAll();

            //if (books is null)
            //    throw new DescriptionBookNotFoundException();

            return books;
        }

        // Данный метод возвращает конкретную запись описания книги по его индентификатору.
        // В случае пустоты получаемой записи выходит исключение.
        public DescriptionBook ReadOne(int id)
        {
            var book = _repository.ReadOne(id);

            if (book is null)
                throw new DescriptionBookNotFoundException();

            return book;
        }

        // Данный метод получает на вход данные для изменения записи описания книги по
        // индентификатору = id, проверяет существование записи, корректности данных 
        // столбец = nameColumn , значение = value. В случае несоответсвия данных 
        // требования выходит ошибка.
        public void Update(int id, string nameColumn, string value)
        {
            var book = _repository.ReadOne(id);

            if (book is null)
                throw new DescriptionBookNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(book.Description) && nameColumn != nameof(book.Genre))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _repository.Update(id, nameColumn, value);
        }
    }
}
