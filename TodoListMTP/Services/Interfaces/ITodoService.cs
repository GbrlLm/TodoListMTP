using TodoListMTP.Models;

namespace TodoListMTP.Services.Interfaces
{
    public interface ITodoService
    {
        Task<TodoTask> GetTask(Guid id);
        Task<IEnumerable<TodoTask>> GetListTask();
        Task<TodoTask> PostTask(TodoTask task);
        Task<TodoTask> UpdateDoneTask(Guid id);
        Task<TodoTask> PutTask(Guid id, TodoTask task);
        void DeleteTask(Guid id);

    }
}
