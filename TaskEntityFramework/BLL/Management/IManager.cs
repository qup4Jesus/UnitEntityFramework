
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management
{
    internal interface IManager<T> where T : Table
    {
        public void Add(string name, string value);
        public List<T> ReadAll();
        public T ReadOne(int id);
        public void Update(int id, string nameColumn, string value);
        public void Delete(int id);

    }
}
