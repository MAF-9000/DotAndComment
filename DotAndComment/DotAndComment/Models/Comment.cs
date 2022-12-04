using System.Text.Json.Serialization;

namespace DotAndComment.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Текст комментария
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Цвет подложки комментария
        /// </summary>
        public string Color { get; set; }

        public Guid DotId { get; set; }
        [JsonIgnore]
        public Dot Dot { get; set; }
    }
}
