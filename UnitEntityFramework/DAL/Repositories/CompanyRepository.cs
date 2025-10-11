
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.DAL.Repositories
{
    internal class CompanyRepository : AbstractRepository<Company>
    {
        public CompanyRepository() : base() { }

        public override void Add(List<Company> newElements)
        {
            using (_db)
            {
                _db.Add(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Company> ReadAll()
        {
            throw new NotImplementedException();
        }

        public override Company ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(int id, string nameColumn, string value)
        {
            throw new NotImplementedException();
        }
    }
}
