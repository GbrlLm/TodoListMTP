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
    }
}
