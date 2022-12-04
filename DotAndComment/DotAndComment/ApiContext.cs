using DotAndComment.Models;
using Microsoft.EntityFrameworkCore;


namespace DotAndComment
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
        {
        }

        public DbSet<Dot> Dots { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Dot)
                .WithMany(d => d.Comments)
                .HasForeignKey(c => c.DotId);
        }
    }
}
