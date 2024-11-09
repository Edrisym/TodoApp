using System;

namespace TodoApp.Models
{
    public class TaskItem : BaseClass
    {

        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; private set; }

        public TaskItem()
        {
        }

        public TaskItem(string title, DateTime? dueDate)
        {
            if (dueDate < DateTime.Now)
                throw new OverdueTaskException("Cannot set a past due date.");

            Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
            DueDate = dueDate;
            IsCompleted = false;
        }

        public void MarkCompleted()
        {
            if (IsCompleted)
                throw new InvalidOperationException("Task is already marked as complete.");

            IsCompleted = true;
        }

        public void MarkUnCompleted()
        {
            if (!IsCompleted)
                throw new InvalidOperationException("Task is already marked as uncompleted.");

            IsCompleted = false;
        }
    }
}