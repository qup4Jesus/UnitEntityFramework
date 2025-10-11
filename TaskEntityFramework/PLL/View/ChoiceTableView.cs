
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.PLL.Helpers;
using TaskEntityFramework.BLL.Entities;

namespace TaskEntityFramework.PLL.View
{
    internal class ChoiceTableView<T> where T : Table
    {
        private IManager<T> _manager;
        private IEntityFactory<T> _entityFactory;

        public ChoiceTableView(IManager<T> manager)
        {
            _manager = manager;
            _entityFactory = _manager.GetFactory();
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine(
                    "Выберите любую из команд: \n" +
                    $"{nameof(Commands.create)} : добавить элемент в таблицу\n" +
                    $"{nameof(Commands.read)} : просмотреть пользователей\n" +
                    $"{nameof(Commands.update)} : обновить пользователя\n" +
                    $"{nameof(Commands.delete)} : удалить пользователя\n");

                switch (Console.ReadLine())
                {
                    case nameof(Commands.create):
                        new AddView<T>(_manager, _entityFactory).Show();
                        break;
                    case nameof(Commands.read):
                        new ReadView<T>(_manager).Show();
                        break;
                    case nameof(Commands.update):
                        new UpdateView<T>(_manager).Show();
                        break;
                    case nameof(Commands.delete):
                        new DeleteView<T>(_manager).Show();
                        break;
                    default:
                        AlertMessages.Show("Неверно выбранный пункт меню");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public enum Commands
        {
            create,
            read,
            update,
            delete
        }
    }
}
