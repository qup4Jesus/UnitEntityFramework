
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    /// <summary>
    /// Данный класс предназаначен для сборки обьектов (Author), после проведения всех
    /// основных проверок поступующих данных.
    /// </summary>
    internal class AuthorFactory : IEntityFactory<Author>
    {
        // Данный метод предназначен для сборки Автора, проверяя поступающие данные на 
        // соответствие типов данных их количества и пустоту для преобразованиия.
        public Author CreateFromUserInput(List<string> input)
        {
            // Проверяем список поступающих данных на пустоту списка. В ином случае вы
            // даем ошибку.
            if (input is null)
                throw new ArgumentNullException();

            // Проверяем список данных на соответсвие требуемому количеству данных. В
            // ином случае выдаем ошибку.
            if (input.Count != 3)
                throw new ArgumentNullException();

            // Проверяем возможноть преобразования данных к типу DateOnly. В ином случае
            // выдаем ошибку.
            if (!DateOnly.TryParse(input[1], out DateOnly result))
                throw new ArgumentNullException();
            if (!DateOnly.TryParse(input[2], out result))
                throw new ArgumentNullException();

            // Приводим требуемые данные к типу DateOnly.
            DateOnly dateBrith = DateOnly.Parse(input[1]);
            DateOnly dateDeath = DateOnly.Parse(input[2]);

            // Создаем новый обьект. Для последующей работы с ним.
            return new Author { Name = input[0], YearBirth = dateBrith, YearDeath = dateDeath };
        }
    }
}
