namespace MiddleTests;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class OrderAttribute(int order) : Attribute
{
    public int Order { get; private set; } = order;
}