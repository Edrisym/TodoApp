namespace TodoApp.Exceptions;

public class OverdueTaskException(string message) : Exception(message);