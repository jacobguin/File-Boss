namespace Middle;

public class UIException : Exception
{
    public UIException(string message, ErrorType et = ErrorType.User) : base(message)
    {
        ErrorType = et;
    }
    
    public ErrorType ErrorType { get; init; }
}