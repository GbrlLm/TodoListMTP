using Microsoft.EntityFrameworkCore;
using TodoListMTP.Models;

namespace TodoListMTP.Configuration.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TodoTask> Todo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TodoTask>(entity => entity.HasKey("id"));
        }
    }
}
