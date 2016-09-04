
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConsoleApplication
{
    public class DemoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DemoRepro;Trusted_Connection=true;")
                .ConfigureWarnings(wc => wc.Throw(RelationalEventId.QueryClientEvaluationWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MainEntity>()
                .HasOne(m => m.Child).WithMany().IsRequired(false);
        }
    }

    public class MainEntity
    {
        public int Id { get; set; }
        public ChildEntity Child { get; set; } 
    }

    public class ChildEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}