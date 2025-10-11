
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class AddView<T> where T : Table
    {
        private IManager<T> _manager;
        private IEntityFactory<T> _factory;

        public AddView(IManager<T> manager, IEntityFactory<T> factory)
        {
            _manager = manager;
            _factory = factory;
        }

        public void Show()
        {
            SuccessMessages.Show("Добавление нового элемента");

            Console.WriteLine("Для добавления нового элемента укажите эти данные: ");

            switch (_manager)
            {
                case ManagerUser managerUser:

                    Console.Write("Введите имя : ");
                    string name = Console.ReadLine();

                    Console.Write("Введите email : ");
                    string email = Console.ReadLine();

                    var listElements = new List<string> { name, email };

                    T newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<T> { newItem });

                    break;
                case ManagerBook managerBook:

                    Console.Write("Введите название : ");
                    string title = Console.ReadLine();

                    Console.Write("Введите дату релиза (В формате YYYY-MM-DD): ");
                    string dateRelease = Console.ReadLine();

                    listElements = new List<string> { title, dateRelease };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<T> { newItem });

                    break;
                case ManagerDescriptionBook managerDescriptionBook:

                    Console.Write("Введите описание книги : ");
                    string description = Console.ReadLine();

                    Console.Write("Введите жанр : ");
                    string genre = Console.ReadLine();
                    
                    listElements = new List<string> { description, genre };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<T> { newItem });

                    break;
                case ManagerAuthor managerAuthor:

                    Console.Write("Введите имя автора : ");
                    name = Console.ReadLine();

                    Console.Write("Введите годы жизни : ");
                    string dateBirth = Console.ReadLine();

                    Console.Write("Введите годы смерти : ");
                    string dateDeath = Console.ReadLine();

                    listElements = new List<string> { name, dateBirth, dateDeath };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<T> { newItem });

                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
