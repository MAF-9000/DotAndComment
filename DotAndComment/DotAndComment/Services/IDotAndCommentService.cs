using DotAndComment.Models;

namespace DotAndComment.Services
{
    public interface IDotAndCommentService
    {
        /// <summary>
        /// Получить все точки
        /// </summary>
        public Task<List<Dot>> GetAll();

        /// <summary>
        /// Создать случайную точку и комментарий к ней
        /// </summary>
        public void AddRandom();

        /// <summary>
        /// Удалить точку
        /// </summary>
        /// <param name="id">Идентификатор точки</param>
        Task<bool> Delete(Guid id);
    }
}
