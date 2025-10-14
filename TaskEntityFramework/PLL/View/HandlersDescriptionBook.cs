
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class HandlersDescriptionBook
    {
        private DescriptionBookManager _manager;
        private DescriptionBookFactory _factory;

        public HandlersDescriptionBook()
        {
            _manager = new DescriptionBookManager();
            _factory = new DescriptionBookFactory();
        }

        public void Check(string descriptionId)
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

                    new HandlersAuthor().Check(idAuthor);

                    var listElements = new List<string> { description, genre, idAuthor };

                    var newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<DescriptionBook> { newItem });
                }
            }
        }
    }
}
