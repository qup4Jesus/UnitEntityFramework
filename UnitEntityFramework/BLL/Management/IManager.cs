
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.BLL.Management
{
    internal interface IManager<T> where T : Table
    {
        public void Add(List<T> newElements);
        public List<T> ReadAll();
        public T ReadOne(int id);
        public void Update(int id, string nameColumn, string value);
        public void Delete(int id);

    }
}
