
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.DAL.SQLRequest
{
    internal abstract class Requests<TEntity, TDto> 
        where TEntity : Table
        where TDto : Table
    {
        protected private MyAppContext _db;

        public Requests()
        {
            _db = new MyAppContext();
        }

        public abstract List<TEntity> Find(int whereValue);
        public abstract List<TEntity> Find(string whereValue, string nameColumn);
        public abstract TEntity FindFirst();
        public abstract List<TDto> Join(Table table);
        public abstract int Sum();
    }
}
