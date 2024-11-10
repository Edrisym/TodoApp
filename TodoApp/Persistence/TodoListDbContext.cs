namespace TodoApp.Persistence;

public class TodoListDbContext(DbContextOptions<TodoListDbContext> options) : DbContext(options)
{
    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(10)
                .HasDefaultValue("Untitled List");

            builder.OwnsMany<TaskItem>(x => x.TaskItems, taskItem =>
            {
                taskItem.HasKey(x => x.Id);

                taskItem.Property(x => x.Description)
                    .IsRequired(false)
                    .HasMaxLength(300);

                taskItem.Property(x => x.Title)
                    .HasMaxLength(100)
                    .IsRequired()
                    .HasDefaultValue("Untitled Task");

                taskItem.Property(x => x.DueDate)
                    .IsRequired(false)
                    .HasMaxLength(15);

                taskItem.Property(x => x.IsCompleted);

                taskItem.Property(x => x.CreatedOn)
                    .HasDefaultValueSql("GETDATE()");

                taskItem.Property(x => x.UpdatedOn)
                    .HasDefaultValueSql("GETDATE()");
            });

            builder.Property(x => x.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.UpdatedOn)
                .HasDefaultValueSql("GETDATE()");
        });
    }
}