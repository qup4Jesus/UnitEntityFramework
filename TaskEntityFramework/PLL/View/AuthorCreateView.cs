
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    /// <summary>
    /// Данный класс руководит за дополнительное создание объекта при инциализации нового Описания книги (DescriptionBook) -
    /// конкретная реализация находится по пути .../PLL/View/AddView строка 110 + вспомогательный класс DescriptionBookCreateView
    /// по пути .../PLL/View/DescriptionBookCreateView строка 46.
    /// </summary>
    internal class AuthorCreateView
    {
        // Данное свойство отвечает за обьект работающий с данными в БД.
        private AuthorManager _manager;

        // Данное свойство отвечает за фабрику-сборщик обьекта для работы с ним.
        private AuthorFactory _factory;

        public AuthorCreateView()
        {
            _manager = new AuthorManager();
            _factory = new AuthorFactory();
        }

        // Метод проверки.
        public string Check(string authorId)
        {
            if (int.TryParse(authorId, out int result))
            {
                if (int.Parse(authorId) == 0)
                {
                    SuccessMessages.Show(
                        "\n" +
                        "Для создания книги требуется создать её автора!\n");
                    Console.Write("Введите имя автора : ");
                    string name = Console.ReadLine();

                    Console.Write("Введите дату рождения : ");
                    string yearBirth = Console.ReadLine();

                    Console.Write("Введите дату смерти : ");
                    string yearDeath = Console.ReadLine();

                    var listElements = new List<string> { name, yearBirth, yearDeath };

                    var newItem = _factory.CreateFromUserInput(listElements);
                    _manager.Add(new List<Author> { newItem });

                    return (_manager.ReadAll().LastOrDefault().Id).ToString();
                }
            }

            return authorId;
        }
    }
}
