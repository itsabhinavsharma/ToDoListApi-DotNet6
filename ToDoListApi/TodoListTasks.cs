namespace ToDoListApi
{
    public class TodoListTasks
    {
        public int Id { get; set; }
        public string? TaskTitle { get; set; }
        public bool IsCompleted { get; set; }
        public string? TaskCategory { get; set; }
    }
}
