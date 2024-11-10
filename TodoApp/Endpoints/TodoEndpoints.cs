using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Endpoints;

public static class TodoEndpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        var todoGroup = app.MapGroup("/api/v1/todo");


        todoGroup.MapPost("/",
            async Task<IResult> ([FromBody] TodoList todoList, TodoListDbContext context) =>
            {
                try
                {
                    await context.TodoLists.AddAsync(todoList);
                    await context.SaveChangesAsync();

                    return Results.Ok(todoList);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Results.BadRequest(StatusCodes.Status500InternalServerError);
                }
            });


        todoGroup.MapGet("/",
            async Task<IResult> (TodoListDbContext context) =>
            {
                try
                {
                    var todos = await context.TodoLists.ToListAsync();
                    return Results.Ok(todos);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return Results.BadRequest(StatusCodes.Status500InternalServerError);
                }
            });

        todoGroup.MapPost("/{todoListId:guid}/tasks",
            async Task<IResult> (Guid todoListId, [FromBody] TaskItem taskItem, TodoListDbContext context) =>
            {
                try
                {
                    var todoList = await context.TodoLists
                        .Include(t => t.TaskItems)
                        .FirstOrDefaultAsync(t => t.Id == todoListId);

                    if (todoList == null)
                    {
                        return Results.NotFound(new { message = "TodoList not found" });
                    }

                    todoList.AddTaskItem(taskItem);
                    await context.SaveChangesAsync();

                    return Results.Ok(todoList);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Results.BadRequest(new { error = e.Message });
                }
            });
    }
}