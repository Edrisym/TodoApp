namespace TodoApp.Models;

public class TodoList : BaseClass
{
    private readonly List<TaskItem> _taskItems = [];
    public IReadOnlyList<TaskItem> TaskItems => [.. _taskItems.AsReadOnly()];


    public TodoList(IEnumerable<TaskItem> taskItem)
    {
        if (taskItem is null)
        {
            throw new ArgumentNullException();
        }
    }
}