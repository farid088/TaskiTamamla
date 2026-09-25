public static class ProductExtensions
{
    public static bool IsInStock(this Product product)
    {
        return product.Stock > 0;
    }
    public static double GetFinalPrice(this Product product, double discountPercentage)
    {
        if (discountPercentage < 0 || discountPercentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 100.");
        }
        return product.Price - (product.Price * (discountPercentage / 100));
    }
    public static bool IsExpensive(this Product product, double price)
    {
        return product.Price > price;
    }
}