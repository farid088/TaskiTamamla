public class ElectronicProduct 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }  
    public string Brand { get; set; }
    public int WarrantyMonth{ get; set; }
    public void GetProductInfo()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Price: {Price}, Stock: {Stock}, Brand: {Brand}, WarrantyMonth: {WarrantyMonth}");
    }
    public void CalculateDiscount(ref decimal price, decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage), "Discount percentage must be between 0 and 100.");
        }
        price -= price * (percentage / 100);
    }
    public void GetFinalPrice(decimal price, decimal discountPercentage)
    {
        CalculateDiscount(ref price, discountPercentage);
        Console.WriteLine($"Final Price after {discountPercentage}% discount: {price}");
    }   
    public bool IsInStock(int quantity)
    {
        return Stock >= quantity;
    }

  
    public void GetTypeInfo()
    {
        Type type = this.GetType();
        Console.WriteLine($"Class Name: {type.Name}");
        Console.WriteLine("Properties:");
        foreach (var prop in type.GetProperties())
        {
            Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
        }
    }
    public void TypeOf()
    {
        Type type = this.GetType();
        Console.WriteLine($"Type of the object: {type}");
    }
    public void GetProperties()
    {
        Type type = this.GetType();
        var properties = type.GetProperties();
        Console.WriteLine("Properties:");
        foreach (var prop in properties)
        {
            Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
        }
    }
    public void GetMethods()
    {
        Type type = this.GetType();
        var methods = type.GetMethods();
        Console.WriteLine("Methods:");
        foreach (var method in methods)
        {
            Console.WriteLine($"- {method.Name} ({method.ReturnType.Name})");
        }
    }
    public void GetPropertyValue(string propertyName)
    {
        Type type = this.GetType();
        var property = type.GetProperty(propertyName);
        if (property != null)
        {
            var value = property.GetValue(this);
            Console.WriteLine($"Value of {propertyName}: {value}");
        }
        else
        {
            Console.WriteLine($"Property {propertyName} not found.");
        }
    }

}