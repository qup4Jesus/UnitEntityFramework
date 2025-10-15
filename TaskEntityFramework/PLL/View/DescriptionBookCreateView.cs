
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class DescriptionBookCreateView
    {
        private DescriptionBookManager _manager;
        private DescriptionBookFactory _factory;

        public DescriptionBookCreateView()
        {
            _manager = new DescriptionBookManager();
            _factory = new DescriptionBookFactory();
        }

        public string Check(string descriptionId)
        {
            if (int.TryParse(descriptionId, out int result))
            {
                if (int.Parse(descriptionId) == 0)
                {
                    AlertMessages.Show("Для создания книги требуется создать её описание!\n");
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
                        Console.WriteLine($"id : {author.Id}");
                    }

                    Console.Write("Введите автора (id) : ");
                    string idAuthor = Console.ReadLine();

                    string id = new AuthorCreateView().Check(idAuthor);

                    var listElements = new List<string> { description, genre, id };

                    var newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<DescriptionBook> { newItem });

                    return (_manager.ReadAll().LastOrDefault().Id).ToString();
                }
            }

            return descriptionId;
        }
    }
}
