
using UnitEntityFramework.DAL.Model;
using UnitEntityFramework.DAL.Model.DTO;

namespace UnitEntityFramework.DAL.SQLRequest
{
    internal class UserCredentialsRequest : Requests<UserCredentials, UserCredentialsUserDto>
    {
        public UserCredentialsRequest() : base() { }

        public override List<UserCredentials> Find(int whereValue)
        {
            using (_db)
            {
                return _db.UserCredentials.Where(u => u.Id == whereValue).ToList();
            }
        }

        public override List<UserCredentials> Find(string whereValue, string nameColumn)
        {
            using (_db)
            {
                switch (nameColumn)
                {
                    case "Login":
                        return _db.UserCredentials.Where(u => u.Login == whereValue).ToList();
                    case "Password":
                        return _db.UserCredentials.Where(u => u.Password == whereValue).ToList();
                    default:
                        return null;
                }
            }
        }

        public override UserCredentials FindFirst()
        {
            return _db.UserCredentials.First();
        }

        public override List<UserCredentialsUserDto> Join(Table table)
        {
            return _db.UserCredentials
                .Join(_db.Users,
                    c => c.UserId,
                    u => u.Id,
                    (u, c) => new UserCredentialsUserDto { UserName = c.Name }).ToList();

        }

        public override int Sum()
        {
            return _db.UserCredentials.Sum(u => u.Id);
        }
    }
}
