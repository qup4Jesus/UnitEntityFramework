
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class DeleteView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    { 
        private IManager<TEntity, TDto> _manager;

        public DeleteView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        public void Show()
        {
            SuccessMessages.Show("Удаление элемента по ID");

            Console.Write("Укажите ID элемента : ");
            int id = int.Parse(Console.ReadLine());

            _manager.Delete(id);
        }
    }
}
