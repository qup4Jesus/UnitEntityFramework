
using UnitEntityFramework.DAL.Repositories;
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.BLL.Management
{
    internal class ManagerUserCredentials : IManager<UserCredentials>
    {
        private UserCredentialsRepository _manager;

        public ManagerUserCredentials()
        {
            _manager = new UserCredentialsRepository();
        }

        public void Add(List<UserCredentials> userCredentials)
        {
            foreach (var user in userCredentials)
            {
                if (String.IsNullOrEmpty(user.Login))
                    throw new ArgumentNullException();
                if (user.Login.Length < 3)
                    throw new ArgumentNullException();
                if (String.IsNullOrEmpty(user.Password))
                    throw new ArgumentNullException();
                if (user.Password.Length < 8)
                    throw new ArgumentNullException();
            }

            _manager.Add(userCredentials);
        }

        public void Delete(int id)
        {
            var user = _manager.ReadOne(id);

            if (user is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }

        public List<UserCredentials> ReadAll()
        {
            var users = _manager.ReadAll();

            if (users is null)
                throw new ArgumentNullException();

            return users;
        }

        public UserCredentials ReadOne(int id)
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
            if (nameColumn != nameof(user.Login))
                throw new ArgumentNullException();
            if (user.Login.Length < 3)
                throw new ArgumentNullException();
            if (nameColumn != nameof(user.Password))
                throw new ArgumentNullException();
            if (user.Password.Length < 8)
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }
    }
}
