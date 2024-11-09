namespace TodoApp.Models;

public class BaseClass
{
    public Guid Id { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime CreatedBy { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;
    public DateTime UpdatedBy { get; set; }
}