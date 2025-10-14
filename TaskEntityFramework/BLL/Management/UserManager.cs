
using System.ComponentModel.DataAnnotations;
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.DAL.Repositories;

namespace TaskEntityFramework.BLL.Management
{
    internal class UserManager : IManager<User, User>
    {
        private UserRepository _manager;
        private UserFactory _factory;
        public IRequestHandler<User, User> RequestHandlers { get; set; }
        public UserManager()
        {
            _manager = new UserRepository();
            _factory = new UserFactory();
            RequestHandlers = new UserRequestHandler();
        }

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

            _manager.Add(users);
        }

        public List<User> ReadAll()
        {
            var users = _manager.ReadAll();

            if (users.Count == 0)
                throw new UserNotFoundException();

            return users;
        }

        public User ReadOne(int id)
        {
            var user = _manager.ReadOne(id);

            if (user == null) 
                throw new UserNotFoundException();

            return user;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var user = _manager.ReadOne(id);

            if (user is null)
                throw new UserNotFoundException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(user.Name))
                throw new ColumnNotFoundException();
            if (nameColumn != nameof(user.Email))
                throw new ColumnNotFoundException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            if (nameColumn == nameof(user.Email))
                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException();

            _manager.Update(id, nameColumn, value);
        }

        public void Delete(int id)
        {
            var user = _manager.ReadOne(id);

            if (user is null)
                throw new UserNotFoundException();

            _manager.Delete(id);
        }

        public IEntityFactory<User> GetFactory()
        {
            return _factory;
        }
    }
}
