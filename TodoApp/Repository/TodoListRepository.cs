namespace TodoApp.Repository;

public class TodoListRepository(TodoListDbContext context)
{
    private readonly TodoListDbContext _context = context;


    public async Task<List<TodoList>> FetchTodoListsAsync()
    {
        return await _context.TodoLists.ToListAsync();
    }

    public async Task<List<TodoList>> FetchTodoWithIncompleteTasksAsync()
    {
        return await _context.TodoLists
            .Include(tl => tl.TaskItems).ToListAsync();
    }
}