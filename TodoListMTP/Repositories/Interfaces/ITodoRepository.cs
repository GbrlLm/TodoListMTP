using TodoListMTP.Models;

namespace TodoListMTP.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoTask> GetTask(Guid id);
        Task<IEnumerable<TodoTask>> GetListTask();
        Task<TodoTask> PostTask(TodoTask task);
        Task<TodoTask> PutTask(Guid id, TodoTask task);
        Task<TodoTask> UpdateDoneTask(Guid id);
        void DeleteTask(Guid id);
    }
}
