
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal class UserRequest : Requests<User, User>
    {
        public override List<User> Find(int whereValue)
        {
            using (_db = new MyAppContext())
                return _db.Users.Where(u => u.Id == whereValue).ToList();
        }

        public override List<User> Find(string whereValue, string nameColumn)
        {
            using (_db = new MyAppContext())
                switch (nameColumn)
            {
                case "Name":
                    return _db.Users.Where(u => u.Name == whereValue).ToList();
                case "Email":
                    return _db.Users.Where(u => u.Email == whereValue).ToList();
                default:
                    return null;
            }
        }

        public override User FindFirst()
        {
            using (_db = new MyAppContext())
                return _db.Users.First();
        }

        public override List<User> Join()
        {
            using (_db = new MyAppContext())
                return null;
        }

        public override int Sum()
        {
            using (_db = new MyAppContext())
                return _db.Users.Sum(u => u.Id);
        }
    }
}
