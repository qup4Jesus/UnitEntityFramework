
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class UpdateView<T> where T : Table
    {
        private IManager<T> _manager;

        public UpdateView(IManager<T> manager)
        {
            _manager = manager;
        }

        public void Show()
        {
            SuccessMessages.Show("Обновление элемента : ");

            Console.Write("Укажите ID изменяемого объекта : ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Укажите какой столбец вы хотите изменить : ");
            string nameColumn = Console.ReadLine();

            Console.Write("Укажите новое значение : ");
            string value = Console.ReadLine();

            _manager.Update(id, nameColumn, value);
        }
    }
}
