public class ClothingProduct : Product
{
    public string Size { get; set; }
    public string Material { get; set; }
    public string Gender { get; set; }
    public override void GetProductInfo()
    {
        base.GetProductInfo();
        Console.WriteLine($"Size: {Size}");
        Console.WriteLine($"Material: {Material}");
        Console.WriteLine($"Gender: {Gender}");
    }
}