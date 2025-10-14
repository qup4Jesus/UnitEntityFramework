
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal interface IRequestHandler<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        public List<TEntity> Find(int whereValue);
        public List<TEntity> Find(string whereValue, string nameColumn);
        public TEntity FindFirst();
        public List<TDto> Join();
        public int Sum();
    }
}
