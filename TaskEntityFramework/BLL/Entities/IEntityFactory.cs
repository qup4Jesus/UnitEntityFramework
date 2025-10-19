
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    /// <summary>
    /// Данный контракт предназначен для сборки обьектов, после проведения всех основных
    /// проверок поступующих данных.
    /// </summary>
    internal interface IEntityFactory<TEntity> where TEntity : Table
    {
        TEntity CreateFromUserInput(List<string> input);
    }
}
