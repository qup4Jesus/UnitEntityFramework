
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class AddView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        private IManager<TEntity, TDto> _manager;
        private IEntityFactory<TEntity> _factory;

        public AddView(IManager<TEntity, TDto> manager, IEntityFactory<TEntity> factory)
        {
            _manager = manager;
            _factory = factory;
        }

        public void Show()
        {
            SuccessMessages.Show("Добавление нового элемента\n");

            Console.WriteLine("Для добавления нового элемента укажите эти данные: ");

            switch (_manager)
            {
                case UserManager managerUser:

                    Console.Write("Введите имя : ");
                    string name = Console.ReadLine();

                    Console.Write("Введите email : ");
                    string email = Console.ReadLine();

                    var listElements = new List<string> { name, email };

                    TEntity newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                case BookManager managerBook:

                    Console.Write("Введите название : ");
                    string title = Console.ReadLine();

                    Console.Write("Введите дату релиза (В формате YYYY-MM-DD): ");
                    string dateRelease = Console.ReadLine();

                    listElements = new List<string> { title, dateRelease };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                case DescriptionBookManager managerDescriptionBook:

                    Console.Write("Введите описание книги : ");
                    string description = Console.ReadLine();

                    Console.Write("Введите жанр : ");
                    string genre = Console.ReadLine();
                    
                    listElements = new List<string> { description, genre };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                case AuthorManager managerAuthor:

                    Console.Write("Введите имя автора : ");
                    name = Console.ReadLine();

                    Console.Write("Введите годы жизни : ");
                    string dateBirth = Console.ReadLine();

                    Console.Write("Введите годы смерти : ");
                    string dateDeath = Console.ReadLine();

                    listElements = new List<string> { name, dateBirth, dateDeath };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
