using BlogsServices.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogsServices.Repository
{
    public class BlogsWriterContext : DbContext
    {
        public BlogsWriterContext()
        {
            Database.EnsureCreated();
            base.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Blogs> Blogs { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433; Database=BlogsWriterDB; User=sa; Password=HAL@VSCPassword123; TrustServerCertificate=True;", optionsBuilder => optionsBuilder.CommandTimeout(300));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
