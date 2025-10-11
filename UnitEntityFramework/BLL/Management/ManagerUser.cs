
using System.ComponentModel.DataAnnotations;
using UnitEntityFramework.DAL.Model;
using UnitEntityFramework.DAL.Repositories;

namespace UnitEntityFramework.BLL.Management
{
    internal class ManagerUser : IManager<User>
    {
        private UserRepository _manager;

        public ManagerUser()
        {
            _manager = new UserRepository();
        }

        public void Add(string name, string email)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(email))
                throw new ArgumentNullException();
            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentNullException();

            List<User> newUser = new List<User> { new User { Name = name, Email = email } };

            _manager.Add(newUser);
        }

        public List<User> ReadAll()
        {
            var users = _manager.ReadAll();

            if (users.Count == 0)
                throw new ArgumentNullException();

            return users;
        }

        public User ReadOne(int id)
        {
            var user = _manager.ReadOne(id);

            if (user == null) 
                throw new ArgumentNullException();

            return user;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var user = _manager.ReadOne(id);

            if (user is null)
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(user.Name))
                throw new ArgumentNullException();
            if (nameColumn != nameof(user.Email))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();
            if (nameColumn == nameof(user.Email))
                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }

        public void Delete(int id)
        {
            var user = _manager.ReadOne(id);

            if (user is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }
    }
}
