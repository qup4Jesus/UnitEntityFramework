
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    /// <summary>
    /// Данный класс предназаначен для сборки обьектов (DescriptionBook), после проведения всех
    /// основных проверок поступующих данных.
    /// </summary>
    internal class DescriptionBookFactory : IEntityFactory<DescriptionBook>
    {
        // Данный метод предназначен для сборки Описания Книги, проверяя поступающие данные на 
        // соответствие типов данных их количества и пустоту для преобразованиия.
        public DescriptionBook CreateFromUserInput(List<string> input)
        {
            // Проверяем список поступающих данных на пустоту списка. В ином случае вы
            // даем ошибку.
            if (input is null)
                throw new ArgumentNullException();

            // Проверяем список данных на соответсвие требуемому количеству данных. В
            // ином случае выдаем ошибку.
            if (input.Count != 3)
                throw new ArgumentNullException();

            // Проверяем возможноть преобразования данных к типу int. В ином случае выдаем
            // ошибку.
            if (!int.TryParse(input[2], out int result1))
                throw new ArgumentException();

            // Приводим требуемые данные к типу int.
            int idAuthor = int.Parse(input[2]);

            // Создаем новый обьект. Для последующей работы с ним.
            return new DescriptionBook { Description = input[0], Genre = input[1], AuthorId = idAuthor };
        }
    }
}
