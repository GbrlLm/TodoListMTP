using TodoListMTP.Models;

namespace TodoListMTP.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<TodoTask> GetTask(int id);
        Task<IEnumerable<TodoTask>> GetListTask();
        Task<TodoTask> PostTask(TodoTask task);
        Task<TodoTask> PutTask(int id, TodoTask task);
        Task<TodoTask> UpdateDoneTask(int id);
        void DeleteTask(int id);
    }
}
