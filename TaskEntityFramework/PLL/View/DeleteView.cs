
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class DeleteView<T> where T : Table
    { 
        private IManager<T> _manager;

        public DeleteView(IManager<T> manager)
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
