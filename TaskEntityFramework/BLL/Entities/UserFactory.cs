
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    /// <summary>
    /// Данный класс предназаначен для сборки обьектов (User), после проведения всех
    /// основных проверок поступующих данных.
    /// </summary>
    internal class UserFactory : IEntityFactory<User>
    {
        // Данный метод предназначен для сборки Пользователя, проверяя поступающие данные на 
        // соответствие типов данных их количества и пустоту для преобразованиия.
        public User CreateFromUserInput(List<string> input)
        {
            // Проверяем список поступающих данных на пустоту списка. В ином случае вы
            // даем ошибку.
            if (input is null)
                throw new ArgumentNullException();

            // Проверяем список данных на соответсвие требуемому количеству данных. В
            // ином случае выдаем ошибку.
            if (input.Count  != 2)
                throw new ArgumentNullException();

            // Создаем новый обьект. Для последующей работы с ним.
            return new User { Name = input[0], Email = input[1] };
        }
    }
}
