public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(string message) : base(message)
    {
    }
}
public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(string message) : base(message)
    {
    }
}
public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(string message) : base(message)
    {
    }
}
public class OutOfStockException :Exception
{
    public OutOfStockException(string message) : base(message)
    {
    }
}
public class InvalidOrderStatusException : Exception
{
    public InvalidOrderStatusException(string message) : base(message)
    {
    }
}

    