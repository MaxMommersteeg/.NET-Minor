
public class DuplicateOrderException : System.Exception
{
    public DuplicateOrderException() { }
    public DuplicateOrderException(string message) : base(message) { }
    public DuplicateOrderException(string message, System.Exception inner) : base(message, inner) { }
}