
using UnitEntityFramework.DAL.Model;
using UnitEntityFramework.DAL.Model.DTO;

namespace UnitEntityFramework.DAL.SQLRequest
{
    internal class CompanyRequest : Requests<Company, UserCompanyDto>
    {
        public CompanyRequest() : base() { }

        public override List<Company> Find(int whereValue)
        {
            using (_db)
            {
                return _db.Companies.Where(u => u.Id == whereValue).ToList();
            }
        }

        public override List<Company> Find(string whereValue, string nameColumn)
        {
            using (_db)
            {
                switch (nameColumn)
                {
                    case "Name":
                        return _db.Companies.Where(c => c.Name == whereValue).ToList();
                    default:
                        return null;
                }
            }
        }

        public override Company FindFirst()
        {
            return _db.Companies.First();
        }

        public override List<UserCompanyDto> Join(Table table)
        {
            return null;
        }

        public override int Sum()
        {
            return _db.Companies.Sum(u => u.Id);
        }
    }
}

