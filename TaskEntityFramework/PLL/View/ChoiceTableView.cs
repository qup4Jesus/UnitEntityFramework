
using TaskEntityFramework.DAL.Model;
using TaskEntityFramework.BLL.Management;
using TaskEntityFramework.PLL.Helpers;
using TaskEntityFramework.BLL.Entities;
using TaskEntityFramework.BLL.Exceptions;

namespace TaskEntityFramework.PLL.View
{
    internal class ChoiceTableView<TEntity, TDto>
        where TEntity : Table
        where TDto : Table
    {
        private IManager<TEntity, TDto> _manager;
        private IEntityFactory<TEntity> _entityFactory;

        public ChoiceTableView(IManager<TEntity, TDto> manager)
        {
            _manager = manager;
            _entityFactory = _manager.GetFactory();
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(
                    "Выберите любую из команд : \n" +
                    $"{nameof(Commands.create)} : добавить элемент в таблицу\n" +
                    $"{nameof(Commands.read)} : просмотреть пользователей\n" +
                    $"{nameof(Commands.update)} : обновить пользователя\n" +
                    $"{nameof(Commands.delete)} : удалить пользователя\n" +
                    $"<-- Назад <<<");

                try
                {
                    switch (Console.ReadLine().ToLower())
                    {
                        case nameof(Commands.create):
                            new AddView<TEntity, TDto>(_manager, _entityFactory).Show();
                            break;
                        case nameof(Commands.read):
                            new ReadView<TEntity, TDto>(_manager).Show();
                            break;
                        case nameof(Commands.update):
                            new UpdateView<TEntity, TDto>(_manager).Show();
                            break;
                        case nameof(Commands.delete):
                            new DeleteView<TEntity, TDto>(_manager).Show();
                            break;
                        case "назад":
                            return;
                        default:
                            AlertMessages.Show("Неверно выбранный пункт меню");
                            break;
                    }
                }
                catch (ColumnNotFoundException)
                {
                    AlertMessages.Show("Указанный столбец не найден!");
                }
                catch (NotAssociationException)
                {
                    AlertMessages.Show("Столбец не имеет связей!");
                }
                catch (UserNotFoundException)
                {
                    AlertMessages.Show("Пользователь не найден!");
                }
                catch (BookNotFoundException)
                {
                    AlertMessages.Show("Книга не найдена!");
                }
                catch (DescriptionBookNotFoundException)
                {
                    AlertMessages.Show("Описание найдено!");
                }
                catch (AuthorNotFoundException)
                {
                    AlertMessages.Show("Автор не найден!");
                }
                catch (ArgumentException)
                {
                    AlertMessages.Show("Неверный формат данных");
                }
                catch (Exception ex)
                {
                    AlertMessages.Show(
                        $"Неизвестная ошибка... {ex.Message}\n" +
                        $"Подробности : {ex.InnerException?.Message}");
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
