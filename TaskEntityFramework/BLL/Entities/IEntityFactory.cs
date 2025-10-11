
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    internal interface IEntityFactory<T> where T : Table
    {
        T CreateFromUserInput(List<string> input);
    }
}
