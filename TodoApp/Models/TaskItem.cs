using TodoApp.Exceptions;

namespace TodoApp.Models;

public class TaskItem
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(string title, DateTime? dueDate)
    {
        if (dueDate < DateTime.Now)
            throw new OverdueTaskException("");


        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException();

        Title = title;
        DueDate = dueDate;
    }
}