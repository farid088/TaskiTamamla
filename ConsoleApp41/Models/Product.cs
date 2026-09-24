public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public ProductCategory Category { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set;}
    public virtual void  GetProductInfo()
    {
        Console.WriteLine($"Product ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Stock: {Stock}");
        Console.WriteLine($"Category: {Category}");
        Console.WriteLine($"Is Deleted: {IsDeleted}");
        Console.WriteLine($"Created At: {CreatedAt}");
    }
    public void CalculateDiscount(double discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100.");
        }
        Price -= Price * (discountPercentage / 100);
    }
}