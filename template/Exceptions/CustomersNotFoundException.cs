namespace template.Exceptions;

public class CustomersNotFoundException:Exception
{
    public CustomersNotFoundException(string message) : base(message)
    {
    }
}