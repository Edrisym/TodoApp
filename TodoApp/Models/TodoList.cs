namespace TodoApp.Models;

public class TodoList : BaseClass
{
    public TodoList()
    {
    }

    private readonly List<TaskItem> _taskItems = new();
    public IReadOnlyList<TaskItem> TaskItems => _taskItems.AsReadOnly();


    public TodoList(IEnumerable<TaskItem> taskItems)
    {
        if (taskItems is null)
        {
            throw new ArgumentNullException();
        }

        _taskItems.AddRange(taskItems);
    }
}