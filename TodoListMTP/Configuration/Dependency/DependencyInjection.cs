using TodoListMTP.Configuration.Context;
using TodoListMTP.Repositories;
using TodoListMTP.Repositories.Interfaces;
using TodoListMTP.Services;
using TodoListMTP.Services.Interfaces;

namespace TodoListMTP.Configuration.Dependency
{
    public static class DependencyInjection
    {
        public static void Registers(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<EntityContext>();
            services.AddTransient<ITodoRepository, TodoRepository>();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
        }
    }
}
