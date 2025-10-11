
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
                // Добавление одной компании, для добавление нескольких
                // компаний используем AddRange(element1, ... ,element54);
                _db.Add(newElements);

                _db.SaveChanges();
            }
        }

        public override void Delete(int id)
        {
            using (_db)
            {
                // Удаление конкретной компании по Id
                var company = _db.Companies.Find(id);

                // Удаление одной компании для удаления нескольких
                // компаний используем RemoveRange(element1, ... ,element72);
                _db.Companies.Remove(company);

                _db.SaveChanges();
            }
        }

        public override List<Company> ReadAll()
        {
            using (_db)
            {
                // Получение всех существующих компаний в БД
                return _db.Companies.ToList();
            }
        }

        public override Company ReadOne(int id)
        {
            using (_db)
            {
                // Конкретной компании по Id
                var company = _db.Companies.Find(id);

                return company;
            }

        }

        public override void Update(int id, string nameColumn, string value)
        {
            using (_db)
            {
                // Изменение компании по ее Id
                var company = _db.Companies.Find(id);

                switch (nameColumn)
                {
                    case nameof(company.Name):
                        company.Name = value;
                        break;
                    default:
                        throw new Exception();
                }

                _db.SaveChanges();
            }
        }
    }
}
