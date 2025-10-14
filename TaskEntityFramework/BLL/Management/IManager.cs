
using TaskEntityFramework.BLL.Management.RequestHandlers;
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Management
{
    internal interface IManager<TEntity, TDto> 
        where TEntity : Table
        where TDto : Table
    {
        public IRequestHandler<TEntity, TDto> RequestHandlers { get; set; }

        public void Add(List<TEntity> listElements);
        public List<TEntity> ReadAll();
        public TEntity ReadOne(int id);
        public void Update(int id, string nameColumn, string value);
        public void Delete(int id);

        public IEntityFactory<TEntity> GetFactory();
    }
}
