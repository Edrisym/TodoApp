using System.Globalization;
using Castle.Components.DictionaryAdapter.Xml;

namespace TodoApp.Tests;

public class TodoListDomainTests
{
    [Fact]
    public void Should_Throw_ArgumentNullException_When_TodoList_Is_Created_With_Null_TaskItem()
    {
        var todoList = () => new TodoList(taskItem: null!);
        todoList.Should().ThrowExactly<ArgumentNullException>();
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_When_TaskItem_Has_No_Title()
    {
        var taskItem = () => new TaskItem(title: null!, null);

        taskItem.Should().ThrowExactly<ArgumentNullException>();
    }

    [Theory]
    [InlineData("Write Test")]
    public void Should_Throw_OverdueTaskException_When_DueDate_Is_Over(string title)
    {
        var taskItem = new TaskItem(title, DateTime.Now.AddDays(1));
        taskItem.DueDate.Should().NotBeBefore(DateTime.Now);
    }

    [Fact]
    public void Should_Throw_IsCompletedException_When_Task_Is_Completed_Once()
    {
        var taskItem = new TaskItem();
        taskItem.MarkCompleted();

        var secondMarkComplete = () => taskItem.MarkCompleted();
        secondMarkComplete.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Task is already marked as complete");
    }

    [Fact]
    public void Should_Throw_IsUnCompletedException_When_Task_Is_UnCompleted_Once()
    {
        var taskItem = new TaskItem();
        taskItem.MarkCompleted(); 
        taskItem.MarkUnCompleted();

        var secondMarkUnComplete = () => taskItem.MarkUnCompleted();
        secondMarkUnComplete.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Task is already marked as Uncompleted");
    }
}