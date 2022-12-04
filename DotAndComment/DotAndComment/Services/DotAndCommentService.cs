using DotAndComment.Models;
using Microsoft.EntityFrameworkCore;

namespace DotAndComment.Services
{
    public class DotAndCommentService : IDotAndCommentService
    {
        private ApiContext _apiContext;
        private readonly string[] _colors = { "Black", "Grey", "Pink", "Purple", "Yellow", "Violet", "Orange" };
        private readonly string[] _commentTexts = { "Comment1", "Comment2", "Comment3", "Comment4", "Comment5", "long comment without meaning", "Comment7" };

        public DotAndCommentService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<List<Dot>> GetAll()
        {
            return await
                _apiContext
                .Dots
                .Include(d => d.Comments)
                .ToListAsync();
        }

        public void AddRandom()
        {
            Random random = new Random();
            var dot = new Dot()
            {
                Color = _colors[random.Next(0, 7)],
                Comments = new List<Comment>(),
                Id = Guid.NewGuid(),
                Radius = random.Next(10, 100),
                X = random.Next(100, 1000),
                Y = random.Next(100, 600)
            };

            for (int i = 0; i < random.Next(1, 7); i++)
            {
                var comment = new Comment()
                {
                    Id = Guid.NewGuid(),
                    Text = _commentTexts[random.Next(0, 7)],
                    Color = _colors[random.Next(0, 7)],
                    DotId = dot.Id,
                    Dot = dot
                };
                dot.Comments.Add(comment);
            }
            _apiContext.Dots.Add(dot);
            _apiContext.SaveChanges();
        }

        public async Task<bool> Delete(Guid id)
        {
            var dot = await _apiContext.Dots.FirstOrDefaultAsync(i => i.Id == id);
            if (dot != null)
            {
                _apiContext.Dots.Remove(dot);
                await _apiContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
