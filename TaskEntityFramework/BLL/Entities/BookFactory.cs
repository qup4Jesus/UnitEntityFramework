
using TaskEntityFramework.DAL.Model;

namespace TaskEntityFramework.BLL.Entities
{
    /// <summary>
    /// Данный класс предназаначен для сборки обьектов (Book), после проведения всех
    /// основных проверок поступующих данных.
    /// </summary>
    internal class BookFactory : IEntityFactory<Book>
    {
        // Данный метод предназначен для сборки Книги, проверяя поступающие данные на 
        // соответствие типов данных их количества и пустоту для преобразованиия.
        public Book CreateFromUserInput(List<string> input)
        {
            // Проверяем список поступающих данных на пустоту списка. В ином случае вы
            // даем ошибку.
            if (input is null)
                throw new ArgumentNullException();

            // Проверяем список данных на соответсвие требуемому количеству данных. В
            // ином случае выдаем ошибку.
            if (input.Count != 4)
                throw new ArgumentNullException();

            // Проверяем возможноть преобразования данных к типу DateOnly. В ином случае
            // выдаем ошибку.
            if (!DateOnly.TryParse(input[1], out DateOnly result))
                throw new ArgumentNullException();

            // Проверяем возможноть преобразования данных к типу int. В ином случае выдаем
            // ошибку.
            if (!int.TryParse(input[2], out int result1))
                throw new ArgumentException();
            if (!int.TryParse(input[3], out result1))
                throw new ArgumentException();

            // Приводим требуемые данные к типу DateOnly.
            DateOnly date = DateOnly.Parse(input[1]);

            // Приводим требуемые данные к типу int.
            int idUser = int.Parse(input[2]);
            int idDescription = int.Parse(input[3]);

            // Создаем новый обьект. Для последующей работы с ним.
            return new Book { Name = input[0], ReleaseDate = date, UserId = idUser, DescriptionBookId = idDescription };
        }
    }
}
