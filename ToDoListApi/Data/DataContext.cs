using Microsoft.EntityFrameworkCore;

namespace ToDoListApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TodoListTasks> toDoListTasks { get; set; }
    }
}
