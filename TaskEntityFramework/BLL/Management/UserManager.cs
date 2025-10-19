
using System.ComponentModel.DataAnnotations;
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    /// <summary>
    /// Данный класс предназначен для реализации обьекта менеджера (Manager) работающего
    /// с хранилищем (Repository => UserRepository) .
    /// </summary>
    internal class UserManager : IManager<User, User>
    {
        // Данное свойство отвечает за объект (хранилище) который общается с БД.
        private UserRepository _repository;

        // Данное свойство отвечает за объект (фабрику-сборщик) который собирает коллекцию
        // обьектов (User).
        public IEntityFactory<User> _factory { get; set; }

        // Данное свойство отвечает за объект (обработчик запросов) которые выполняет 
        // проверки данных для работы с запросами.
        public IRequestHandler<User, User> RequestHandlers { get; set; }

        public UserManager()
        {
            _repository = new UserRepository();
            _factory = new UserFactory();
            RequestHandlers = new UserRequestHandler();
        }

        // Данный метод получет на вход список сгенерированных фабрикой (UserFactory)
        // пользователей (User) и проверяет каждого на соответствие данных критериям.
        // В случае несоответствия критериям выходит исключение.
        public void Add(List<User> users)
        {
            foreach (var user in users)
            {
                if (String.IsNullOrEmpty(user.Name))
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(user.Email))
                    throw new ArgumentNullException();
                if (!new EmailAddressAttribute().IsValid(user.Email))
                    throw new ArgumentException();
            }

            _repository.Add(users);
        }

        // Данный метод возвращает список всех записей пользователей находящихся в БД.
        // В случае пустоты получаемого списка выходит исключение.
        public List<User> ReadAll()
        {
            var users = _repository.ReadAll();

            if (users.Count == 0)
                throw new UserNotFoundException();

            return users;
        }

        // Данный метод возвращает конкретную запись пользователя по индентификатору.
        // В случае пустоты получаемой записи выходит исключение.
        public User ReadOne(int id)
        {
            var user = _repository.ReadOne(id);

            if (user == null) 
                throw new UserNotFoundException();

            return user;
        }

        // Данный метод получает на вход данные для изменения записи пользователя по
        // индентификатору = id, проверяет существование записи, корректности данных 
        // столбец = nameColumn , значение = value. В случае несоответсвия данных 
        // требования выходит ошибка.
        public void Update(int id, string nameColumn, string value)
        {
            var user = _repository.ReadOne(id);

            if (user is null)
                throw new UserNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(user.Name) && nameColumn != nameof(user.Email))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            if (nameColumn == nameof(user.Email))
                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException();

            _repository.Update(id, nameColumn, value);
        }

        // Данный метод удаляет конкретную запись пользователя по индентификатору.
        // В случае пустоты записи выходит исклюение.
        public void Delete(int id)
        {
            var user = _repository.ReadOne(id);

            if (user is null)
                throw new UserNotFoundException();

            _repository.Delete(id);
        }
    }
}
