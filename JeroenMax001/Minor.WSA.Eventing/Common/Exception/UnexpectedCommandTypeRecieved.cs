using System;

public class UnexpectedCommandTypeRecievedException : Exception
{
    public UnexpectedCommandTypeRecievedException()
    {
    }

    public UnexpectedCommandTypeRecievedException(string message) : base(message)
    {
    }

    public UnexpectedCommandTypeRecievedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}