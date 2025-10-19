
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    /// <summary>
    /// Данный класс отвечает за ввывод в консоль данных. Меню удаления объекта.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table для универсальной
    /// работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DateTransferObject для 
    /// универсальной работы </typeparam>
    internal class DeleteView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        // Данное свойство отвечает за обьект работающий с данными в БД.
        private IManager<TEntity, TDto> _manager;

        public DeleteView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        // Меню удаления объекта.
        public void Show()
        {
            Console.Clear();

            SuccessMessages.Show("Удаление элемента по ID");

            Console.Write("Укажите ID элемента : ");
            int id = int.Parse(Console.ReadLine());

            _manager.Delete(id);
        }
    }
}
