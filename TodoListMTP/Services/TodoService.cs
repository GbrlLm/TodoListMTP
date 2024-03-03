using System.Threading.Tasks;
using TodoListMTP.Models;
using TodoListMTP.Repositories.Interfaces;
using TodoListMTP.Services.Interfaces;

namespace TodoListMTP.Services
{
    public class TodoService : ITodoService
    {
        private ITodoRepository _todoRepository;
        public TodoService(ITodoRepository todoRepository) 
        {
            _todoRepository = todoRepository;   
        }

        public async Task<TodoTask> GetTask(int id)
        {
            return await _todoRepository.GetTask(id);
        }

        public async Task<IEnumerable<TodoTask>> GetListTask()
        {
            return await _todoRepository.GetListTask();
        }

        public async Task<TodoTask> PostTask(TodoTask task)
        {
            try
            {
                return await _todoRepository.PostTask(task);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<TodoTask> UpdateDoneTask(int id)
        {
            try
            {
                return await _todoRepository.UpdateDoneTask(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<TodoTask> PutTask(int id, TodoTask task) 
        {
            try
            {
                return await _todoRepository.PutTask(id, task);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  

        public async void DeleteTask(int id)
        {
            try
            {
                _todoRepository.DeleteTask(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
