using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Endpoints;

public static class TodoEndpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/todo");


        group.MapPost("/", async Task<string> ([FromBody] TodoList todoList) =>
        {
            return "";
        });
    }
}