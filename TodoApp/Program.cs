var builder = WebApplication.CreateBuilder(args);

builder.AddToDoListDbContext();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.Run();
app.MapEndpoints();
app.UseRouting();

public static class ServiceActivationExtensions
{
    public static void AddToDoListDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<TodoListDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    }
}