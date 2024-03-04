using Microsoft.EntityFrameworkCore;
using TodoListMTP.Models;

namespace TodoListMTP.Configuration.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<TodoTask> Todo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>(entity => entity.HasKey("Id"));
        }
    }
}
