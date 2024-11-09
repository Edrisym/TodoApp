namespace TodoApp.Models;

public class BaseClass
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime CreatedBy { get; set; }

    public DateTime UpdatedOn { get; set; }
    public DateTime UpdatedBy { get; set; }
}