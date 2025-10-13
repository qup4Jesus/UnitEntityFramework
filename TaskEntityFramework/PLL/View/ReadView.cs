
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.PLL.Helpers;

namespace TaskEntityFramework.PLL.View
{
    internal class ReadView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        private IManager<TEntity, TDto> _manager;

        public ReadView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
        }

        public void Show()
        {
            while (true)
            {
                SuccessMessages.Show("Просмотр записей");

                Console.WriteLine("Выберите показ пользователей : \n" +
                    "1 - Показать все записи\n" +
                    "2 - Показать конкретную запись по ID\n" +
                    "3 - Показать записи по условию\n" +
                    "4 - Показать первую запись в таблице\n" +
                    "5 - Показать объединенные таблицы\n" +
                    "6 - Показать сумму ID (???)");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllRecords();
                        break;
                    case "2":
                        ShowRecordById();
                        break;
                    default:
                        AlertMessages.Show("Введено не корректное значение!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowAllRecords()
        {
            List<TEntity> listElem = _manager.ReadAll();

            foreach (TEntity item in listElem)
            {
                if (item is User user)
                {
                    Console.WriteLine(
                        $"Имя пользователя: {user.Name}\n" +
                        $"Email пользователя: {user.Email}\n");
                }
                else if (item is Book book)
                {
                    Console.WriteLine(
                        $"Название книги: {book.Name}\n" +
                        $"Дата выхода: {book.ReleaseDate}\n");
                }
            }
        }

        private void ShowRecordById()
        {
            Console.Write("Введите id: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                TEntity record = _manager.ReadOne(id);

                if (record is User user)
                {
                    Console.WriteLine(
                        $"Имя пользователя: {user.Name}\n" +
                        $"Email пользователя: {user.Email}");
                }
                else if (record is Book book)
                {
                    Console.WriteLine(
                        $"Название книги: {book.Name}\n" +
                        $"Дата выхода: {book.ReleaseDate}");
                }
            }
            else
            {
                AlertMessages.Show("Неверный формат ID!");
            }
        }
    }
}