
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.DAL.Repositories
{
    internal class UserCredentialsRepository : AbstractRepository<UserCredentials>
    {
        public UserCredentialsRepository() : base() { }

        public override void Add(List<UserCredentials> newElements)
        {
            using (_db)
            {
                foreach (var element in newElements)
                {
                    _db.Add(element);
                }

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db)
            {
                var user = _db.UserCredentials.Find(id);

                _db.UserCredentials.Remove(user);
            }

            _db.SaveChanges();
        }

        public override List<UserCredentials> ReadAll()
        {
            using (_db)
            {
                return _db.UserCredentials.ToList();
            }
        }

        public override UserCredentials ReadOne(int id)
        {
            using (_db)
            {
                return _db.UserCredentials.Find(id);
            }
        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db)
            {
                var user = _db.UserCredentials.Find(id);

                switch (nameColumn)
                {
                    case nameof(user.Login):
                        break;
                    case nameof(user.Password):
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
