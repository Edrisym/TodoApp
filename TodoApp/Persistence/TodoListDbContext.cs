using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Persistence;

public class TodoListDbContext(DbContextOptions<TodoListDbContext> options) : DbContext(options)
{
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseClass>(builder =>
        {
            builder.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");
        });


        modelBuilder.Entity<TodoList>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("Untitled List");

            builder.OwnsMany<TaskItem>(x => x.TaskItems);
        });

        modelBuilder.Entity<TaskItem>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(300);

            builder.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired()
                .HasDefaultValue("Untitled Task");

            builder.Property(x => x.DueDate)
                .IsRequired(false)
                .HasMaxLength(15);

            builder.Property(x => x.IsCompleted)
                .HasDefaultValue(false)
                .IsRequired(false);
        });
    }
}