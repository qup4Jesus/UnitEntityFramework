
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

        public void Add(List<User> users)
        {
            foreach (var user in users)
            {
                if (String.IsNullOrEmpty(user.Name))
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(user.Email))
                    throw new ArgumentNullException();
                if (!new EmailAddressAttribute().IsValid(user.Email))
                    throw new ArgumentNullException();
            }
            
            _manager.Add(users);
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
