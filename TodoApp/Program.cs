using TodoApp.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.AddToDoListDbContext();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<TodoListRepository>();

var app = builder.Build();

app.MapEndpoints();
app.Run();


public static class ServiceActivationExtensions
{
    public static void AddToDoListDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<TodoListDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    }
}