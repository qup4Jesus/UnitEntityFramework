
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management.RequestHandlers
{
    internal interface IRequestHandler<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        public List<TEntity> Find(int whereValue);
        public List<TEntity> Find(string whereValue, string nameColumn);

        public List<TEntity> FindTask(int command, string whereValueFirst = null, string whereValueSecond = null, string whereValueTree = null);
        public TEntity FindFirst();
        public List<TDto> Join();
        public int Sum();
    }
}
