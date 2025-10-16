
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.PLL.View
{
    internal class AuthorCreateView
    {
        private AuthorManager _manager;
        private AuthorFactory _factory;

        public AuthorCreateView()
        {
            _manager = new AuthorManager();
            _factory = new AuthorFactory();
        }

        public string Check(string authorId)
        {
            if (int.TryParse(authorId, out int result))
            {
                if (int.Parse(authorId) == 0)
                {
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
