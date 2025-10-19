
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    /// <summary>
    /// Данный класс отвечает за ввывод в консоль данных. Меню добавления записей.
    /// </summary>
    /// <typeparam name="TEntity"> Данный параметр использует сущность Table для универсальной
    /// работы </typeparam>
    /// <typeparam name="TDto"> Данный параметр использует сущность DateTransferObject для 
    /// универсальной работы </typeparam>
    internal class AddView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        // Данное свойство отвечает за обьект работающий с данными в БД.
        private IManager<TEntity, TDto> _manager;

        // Данное свойство отвечает за фабрику-сборщик обьекта для работы с ним.
        private IEntityFactory<TEntity> _factory;

        public AddView(IManager<TEntity, TDto> manager, IEntityFactory<TEntity> factory)
        {
            _manager = manager;
            _factory = factory;
        }

        // Меню добавления записи.
        public void Show()
        {
            Console.Clear();

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

                    Console.Write("Введите дату релиза (В формате YYYY-MM-DD) : ");
                    string dateRelease = Console.ReadLine();

                    Console.Write("Введите пользователя книги (id): ");
                    string idUser = Console.ReadLine();

                    List<DescriptionBook> descriptionBooks = new DescriptionBookManager().ReadAll();

                    Console.WriteLine(
                        $"\n" +
                        $"Количество существующие записей : {descriptionBooks.Count}\n" +
                        "Для создания новой записи требуется выбрать <0>");
                    foreach (var descriptionBook in descriptionBooks)
                    {
                        Console.Write($"id : {descriptionBook.Id}\t");
                    }

                    Console.Write(
                        "\n" +
                        "Введите описание книги (id) : ");
                    string idDescription = Console.ReadLine();

                    idDescription = new DescriptionBookCreateView().Check(idDescription);

                    listElements = new List<string> { title, dateRelease, idUser, idDescription };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                case DescriptionBookManager managerDescriptionBook:

                    Console.Write("Введите описание книги : ");
                    string description = Console.ReadLine();

                    Console.Write("Введите жанр : ");
                    string genre = Console.ReadLine();

                    List<Author> authors = new AuthorManager().ReadAll();

                    Console.WriteLine(
                        $"Количество существующие записей : {authors.Count}\n" +
                        "Для создания новой записи требуется выбрать <0>");
                    foreach (var author in authors)
                    {
                        Console.Write($"id : {author.Id}\t ");
                    }

                    Console.Write(
                        "\n" +
                        "Введите автора (id) : ");
                    string idAuthor = Console.ReadLine();

                    idAuthor = new AuthorCreateView().Check(idAuthor);

                    listElements = new List<string> { description, genre, idAuthor };

                    newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<TEntity> { newItem });

                    break;
                case AuthorManager managerAuthor:

                    Console.Write("Введите имя автора : ");
                    name = Console.ReadLine();

                    Console.Write("Введите годы жизни (В формате YYYY-MM-DD) : ");
                    string dateBirth = Console.ReadLine();

                    Console.Write("Введите годы смерти (В формате YYYY-MM-DD) : ");
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
