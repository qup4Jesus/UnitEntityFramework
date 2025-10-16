
using UnitEntityFramework.DAL.Model;
using UnitEntityFramework.DAL.Model.DTO;

namespace UnitEntityFramework.DAL.SQLRequest
{
    internal class UserRequest : Requests<User, UserCompanyDto>
    {
        public UserRequest() : base() { }

        public override List<User> Find(int whereValue)
        {
            using (_db)
            {
                return _db.Users.Where(u => u.Id == whereValue).ToList();
            }
        }

        public override List<User> Find(string whereValue, string nameColumn)
        {
            using (_db)
            {
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
        }

        public override User FindFirst()
        {
            using (_db)
            {
                return _db.Users.First();
            }  
        }

        public override List<UserCompanyDto> Join(Table table)
        {
            using (_db)
            {
                return _db.Users
                    .Join(_db.Companies,
                        c => c.CompanyId,
                        u => u.Id,
                        (u, c) => new UserCompanyDto { CompanyName = c.Name }).ToList();

            }
        }

        public override int Sum()
        {
            using (_db)
            {
                return _db.Users.Sum(u => u.Id);
            }
        }
    }
}
