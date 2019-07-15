using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Domain
{
    public class BloggingContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<BloggingContext>();
            options.UseSqlServer("INTENTIONALLY LEFT BLANK");
            return new BloggingContext(options.Options);
        }
    }
}
