
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта менеджера (Manager) работающего
    /// с хранилищем (Repository => AuthorRepository) .
    /// </summary>
    internal class AuthorManager : IManager<Author, Author>
    {
        // Данное свойство отвечает за объект (хранилище) который общается с БД.
        private AuthorRepository _manager;

        // Данное свойство отвечает за объект (фабрику-сборщик) который собирает коллекцию
        // обьектов (Author).
        public IEntityFactory<Author> _factory { get; set; }

        // Данное свойство отвечает за объект (обработчик запросов) которые выполняет 
        // проверки данных для работы с запросами.
        public IRequestHandler<Author, Author> RequestHandlers { get; set; }

        public AuthorManager()
        {
            _manager = new AuthorRepository();
            _factory = new AuthorFactory();
            RequestHandlers = new AuthorRequestHandler();
        }

        // Данный метод получет на вход список сгенерированных фабрикой (AuthorFactory)
        // авторов (Author) и проверяет каждого на соответствие данных критериям.
        // В случае несоответствия критериям выходит исключение.
        public void Add(List<Author> listElements)
        {
            foreach (var author in listElements)
            {
                if (String.IsNullOrEmpty(author.Name))
                    throw new ArgumentNullException();
                if (!(author.YearBirth is DateOnly))
                    throw new ArgumentException();
                if (!(author.YearDeath is DateOnly))
                    throw new ArgumentException();
            }

            _manager.Add(listElements);
        }

        // Данный метод удаляет конкретную запись автора по индентификатору.
        // В случае пустоты записи выходит исклюение.
        public void Delete(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();

            _manager.Delete(id);
        }

        // Данный метод возвращает список всех записей авторов находящихся в БД.
        public List<Author> ReadAll()
        {
            var author = _manager.ReadAll();

            //if (author is null)
            //    throw new AuthorNotFoundException();

            return author;
        }

        // Данный метод возвращает конкретную запись автора по индентификатору.
        // В случае пустоты получаемой записи выходит исключение.
        public Author ReadOne(int id)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();

            return author;
        }

        // Данный метод получает на вход данные для изменения записи автора по
        // индентификатору = id, проверяет существование записи, корректности данных 
        // столбец = nameColumn , значение = value. В случае несоответсвия данных 
        // требования выходит ошибка.
        public void Update(int id, string nameColumn, string value)
        {
            var author = _manager.ReadOne(id);

            if (author is null)
                throw new AuthorNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(author.Name) && 
                nameColumn != nameof(author.YearBirth) && 
                nameColumn != nameof(author.YearDeath))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }
    }
}

