using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TodoListMTP.Models;
using TodoListMTP.Services.Interfaces;

namespace TodoListMTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private ITodoService _todoService;
        public TodoController(ILogger<TodoController> logger, ITodoService todoService) 
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var todoTask = await _todoService.GetTask(id);
            return Ok(todoTask);
        }

        [HttpGet]
        public async Task<IActionResult> GetListTasks()
        {
            var todoTaskList = await _todoService.GetListTask();
            return Ok(todoTaskList);
        }

        [HttpPost]
        public async Task<IActionResult> PostTodoTask(TodoTask task)
        {
            try
            {
                var taskCreated = await _todoService.PostTask(task);
                return Ok(taskCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateDoneTask(int id)
        {
            try
            {
                var taskDone = await _todoService.UpdateDoneTask(id);
                return Ok(taskDone);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutTodoTask(int id, TodoTask task)
        {
            try
            {
                var taskUpdated = await _todoService.PutTask(id, task);
                return Ok(taskUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTodoTask(int id)
        {
            try
            {
                _todoService.DeleteTask(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
