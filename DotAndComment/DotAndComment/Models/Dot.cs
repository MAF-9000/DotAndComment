namespace DotAndComment.Models
{
    public class Dot
    {
        /// <summary>
        /// Идентификатор точки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Положение по X
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Положение по Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Радиус точки
        /// </summary>
        public int Radius { get; set; }

        /// <summary>
        /// Цвет точки
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Список комментариев
        /// </summary>
        public List<Comment> Comments { get; set; }

    }
}
