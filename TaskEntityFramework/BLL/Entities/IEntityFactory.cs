
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal interface IEntityFactory<TEntity> where TEntity : Table
    {
        TEntity CreateFromUserInput(List<string> input);
    }
}
