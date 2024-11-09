using TodoApp.Exceptions;

namespace TodoApp.Tests
{
    public class TodoListDomainTests
    {
        #region CreationTests

        [Fact]
        public void Should_Throw_ArgumentNullException_When_TodoList_Is_Created_With_Null_TaskItem()
        {
            var todoListCreation = () => new TodoList(taskItem: null!);
            todoListCreation.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void Should_Throw_ArgumentNullException_When_TaskItem_Has_No_Title()
        {
            var taskItemCreation = () => new TaskItem(title: null!, DateTime.Now.AddDays(1));

            taskItemCreation.Should().ThrowExactly<ArgumentNullException>();
        }

        #endregion

        #region DueDateValidationTests

        [Theory]
        [InlineData("Write Test")]
        public void Should_Throw_OverdueTaskException_When_DueDate_Is_Past(string title)
        {
            var overdueDate = DateTime.Now.AddDays(-1);
            var taskItemCreation = () => new TaskItem(title, overdueDate);

            taskItemCreation.Should().ThrowExactly<OverdueTaskException>()
                .WithMessage("Cannot set a past due date.");
        }

        #endregion

        #region CompletionStatusTests

        [Fact]
        public void Should_Throw_InvalidOperationException_When_Task_Is_Completed_Twice()
        {
            var taskItem = new TaskItem();
            taskItem.MarkCompleted();

            var secondMarkComplete = () => taskItem.MarkCompleted();
            secondMarkComplete.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage("Task is already marked as complete.");
        }

        [Fact]
        public void Should_Throw_InvalidOperationException_When_Task_Is_UnCompleted_Twice()
        {
            var taskItem = new TaskItem();
            taskItem.MarkCompleted();
            taskItem.MarkUnCompleted();

            var secondMarkUnComplete = () => taskItem.MarkUnCompleted();
            secondMarkUnComplete.Should().ThrowExactly<InvalidOperationException>()
                .WithMessage("Task is already marked as uncompleted.");
        }

        #endregion
    }
}