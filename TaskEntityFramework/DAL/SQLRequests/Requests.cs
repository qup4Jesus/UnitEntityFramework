
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.DAL.SQLRequests
{
    internal abstract class Requests<TEntity, TDto> 
        where TEntity : Table
        where TDto : Table
    {
        protected private MyAppContext _db;

        public abstract List<TEntity> Find(int whereValue);
        public abstract List<TEntity> Find(string whereValue, string nameColumn);
        public abstract TEntity FindFirst();
        public abstract List<TDto> Join();
        public abstract int Sum();
    }
}
