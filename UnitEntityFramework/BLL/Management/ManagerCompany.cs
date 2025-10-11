
using UnitEntityFramework.DAL.Model;
using UnitEntityFramework.DAL.Repositories;

namespace UnitEntityFramework.BLL.Management
{
    internal class ManagerCompany: IManager<Company>
    {
        private CompanyRepository _manager;

        public ManagerCompany()
        {
            _manager = new CompanyRepository();
        }

        public void Add(List<Company> companies)
        {
            foreach (var company in companies)
            {
                if (String.IsNullOrEmpty(company.Name))
                    throw new ArgumentNullException();
            }

            _manager.Add(companies);
        }

        public void Delete(int id)
        {
            var company = _manager.ReadOne(id);

            if (company is null)
                throw new ArgumentNullException();

            _manager.Delete(id);
        }

        public List<Company> ReadAll()
        {
            var company = _manager.ReadAll();

            if (company is null)
                throw new ArgumentNullException();

            return company;
        }

        public Company ReadOne(int id)
        {
            var company = _manager.ReadOne(id);

            if (company is null)
                throw new ArgumentNullException();

            return company;
        }

        public void Update(int id, string nameColumn, string value)
        {
            var company = _manager.ReadOne(id);

            if (company is null) 
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(nameColumn))
                throw new ArgumentNullException();
            if (nameColumn != nameof(company.Name))
                throw new ArgumentNullException();
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            _manager.Update(id, nameColumn, value);
        }
    }
}
