namespace TodoApp.Models;

public class TodoList : BaseClass
{
    private List<TaskItem> _taskItems = new();

    public TodoList()
    {
    }

    public IReadOnlyList<TaskItem> TaskItems
    {
        get => _taskItems.AsReadOnly();
        init => _taskItems = (List<TaskItem>)value;
    }

    public TodoList(IEnumerable<TaskItem> taskItems)
    {
        if (taskItems is null)
        {
            throw new ArgumentNullException();
        }

        _taskItems.AddRange(taskItems);
    }

    public void AddTaskItem(TaskItem taskItem)
    {
        if (taskItem != null)
        {
            _taskItems.Add(taskItem);
        }
    }
}