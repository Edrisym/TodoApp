namespace TodoApp.Models;

public class TaskItem : BaseClass
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }


    public TaskItem()
    {
    }

    public TaskItem(string title, DateTime? dueDate)
    {
        if (dueDate < DateTime.Now)
            throw new OverdueTaskException("");


        if (string.IsNullOrEmpty(title))
            throw new ArgumentNullException();

        Title = title;
        DueDate = dueDate;
    }

    public void MarkCompleted()
    {
        if (IsCompleted)
            throw new InvalidOperationException("Task is already marked as complete");

        IsCompleted = true;
    }

    public void MarkUnCompleted()
    {
        if (!IsCompleted)
            throw new InvalidOperationException("Task is already marked as Uncompleted");

        IsCompleted = false;
    }
}