namespace TodoApp.Tests;

public class TodoListTests
{
    [Fact]
    public void Should_Throw_ArgumentNullException_When_TodoList_Is_Created_With_Null_TaskItem()
    {
        var todoList = () => new TodoList(TaskItem: null!);
        todoList.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_When_TaskItem_Has_No_Title()
    {
        var taskItem = () => new TaskItem(null!, DateTime.Now.AddSeconds(10));

        taskItem.Should().ThrowExactly<ArgumentNullException>();
    }


    [Fact]
    public void Should_Return_Empty_List_When_No_Task_Item_Exists()
    {
    }


    [Theory]
    [InlineData("Write Test")]
    public void Should_Throw_Invalid_When_DueDate_Is_Over(string title)
    {
        var taskItem = new TaskItem(title, DateTime.Now.AddSeconds(-1));

        var dueDate = () => taskItem.DueDate.Should().BeBefore(DateTime.Now);
        dueDate.Should().ThrowExactly<OverdueTaskException>();
    }
}

public class TodoList
{
    private readonly List<TaskItem> _taskItems = [];
    public IReadOnlyList<TaskItem> TaskItems => [.. _taskItems.AsReadOnly()];


    public TodoList(IEnumerable<TaskItem> TaskItem)
    {
        if (TaskItem is null)
        {
            throw new ArgumentNullException();
        }
    }
}

public class TaskItem
{
    public Guid TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? CompletedDate { get; set; }

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

public class OverdueTaskException(string message) : Exception(message);