using TodoListMTP.Models;

namespace TodoListMTP.Services.Interfaces
{
    public interface ITodoService
    {
        Task<TodoTask> GetTask(int id);
        Task<IEnumerable<TodoTask>> GetListTask();
        Task<TodoTask> PostTask(TodoTask task);
        Task<TodoTask> UpdateDoneTask(int id);
        Task<TodoTask> PutTask(int id, TodoTask task);
        Task<int> DeleteTask(int id);

    }
}
