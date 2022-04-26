using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private static List<TodoListTasks> ToDoListTasks = new()
        {
            //new TodoList
            //{
            //    Id = 1,
            //    TaskTitle = "Do Work by 4 PM",
            //    IsCompleted = false,
            //    TaskCategory = "Work"
            //},
            //new TodoList
            //{
            //    Id = 2,
            //    TaskTitle = "Play Guitar",
            //    IsCompleted = true,
            //    TaskCategory = "Extra work"
            //}

        };

        private readonly DataContext _context;

        public ToDoListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoListTasks>>> Get()
        {
            return Ok(await _context.toDoListTasks.ToListAsync());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TodoListTasks>> GetById(int Id)
        {
            var Task = await _context.toDoListTasks.FindAsync(Id);
            if(Task == null)
            {
                return BadRequest("Task Doesn't Exist");
            }
            return Ok(Task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TodoListTasks>>> AddTask(TodoListTasks task)
        {
            _context.toDoListTasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(await _context.toDoListTasks.ToListAsync());   
        }

        [HttpPut]
        public async Task<ActionResult<List<TodoListTasks>>> UpdateTask(TodoListTasks updateRequest)
        {
            var task = await _context.toDoListTasks.FindAsync(updateRequest.Id);
            
            if(task == null)
            {
                BadRequest("Task Doesn't Exist");
            }

            task.TaskTitle = updateRequest.TaskTitle;
            task.IsCompleted = updateRequest.IsCompleted;
            task.TaskCategory = updateRequest.TaskCategory; 

            await _context.SaveChangesAsync();

            return Ok(await _context.toDoListTasks.ToListAsync());
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<List<TodoListTasks>>> DeleteTask(int Id)
        {
            var requestedTask = await _context.toDoListTasks.FindAsync(Id);    
            
            if(requestedTask == null)
            {
                BadRequest("Task Doesn't Exist");
            }
            else
            {
                _context.toDoListTasks.Remove(requestedTask);
                await _context.SaveChangesAsync();
            }

            

            return Ok(await _context.toDoListTasks.ToListAsync());
        }
    }
}
