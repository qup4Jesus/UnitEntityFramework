
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class AddView<T> where T : Table
    {
        private IManager<T> _manager;

        public AddView(IManager<T> manager)
        {
            _manager = manager;
        }

        public void Show()
        {
            SuccessMessages.Show("Добавление нового элемента");

            Console.WriteLine("Для добавления нового элемента укажите эти данные: ");

            if (_manager is ManagerUser)
            {
                Console.Write("Имя : ");
                string name = Console.ReadLine();

                Console.Write("Email : ");
                string email = Console.ReadLine();

                _manager.Add(name, email);
            }
            else if (_manager is ManagerBook) 
            {
                Console.Write("Название : ");
                string name = Console.ReadLine();

                Console.Write("Дату издания в формате YYYY-MM-DD : ");
                string date = Console.ReadLine();

                _manager.Add(name, date);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
