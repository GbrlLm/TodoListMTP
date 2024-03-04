using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoListMTP.Configuration.Context;
using TodoListMTP.Models;
using TodoListMTP.Repositories.Interfaces;

namespace TodoListMTP.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly EntityContext _entityContext;

        public TodoRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<TodoTask> GetTask(int id)
        {
            var todoTask = _entityContext.Todo.FindAsync(id).Result;
            return todoTask;
        }

        public async Task<IEnumerable<TodoTask>> GetListTask()
        {
            var listTodoTask = _entityContext.Todo.ToListAsync().Result;
            return listTodoTask;
        }

        public async Task<TodoTask> PostTask(TodoTask task)
        {
            var taskAdded = _entityContext.Todo.Add(task);

            try
            {
                await _entityContext.SaveChangesAsync();
                return taskAdded.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<TodoTask> PutTask(int id, TodoTask task)
        {
            var todoTask = await _entityContext.Todo.FindAsync(id);
            if (todoTask == null)
            {
                return null;
            }

            try
            {
                task.Id = id;
                _entityContext.Todo.Entry(todoTask).CurrentValues.SetValues(task);
                await _entityContext.SaveChangesAsync();
                return task;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TodoTask> UpdateDoneTask(int id)
        {
            var todoDoneTask = await _entityContext.Todo.FindAsync(id);
            if (todoDoneTask == null)
            {
                return null;
            }

            todoDoneTask.Done = !todoDoneTask.Done;
            _entityContext.Todo.Entry(todoDoneTask).CurrentValues.SetValues(todoDoneTask);

            try
            {
                await _entityContext.SaveChangesAsync();
                return todoDoneTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> DeleteTask(int id)
        {
            var data = await _entityContext.Todo.FindAsync(id);
            if (data != null)
            {
                try
                {
                    _entityContext.Todo.Remove(data);
                    return await _entityContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return 0;
        }
    }
}
