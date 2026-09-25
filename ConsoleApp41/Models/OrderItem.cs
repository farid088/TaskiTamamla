public class OrderItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
    public double TotalPrice => Quantity * UnitPrice;
    public bool  TryRemoveFromStock(Product product, int quantity, out decimal totalPrice)
    {
        if (product.Stock >= quantity)
        {
            product.Stock -= quantity;
            totalPrice = (decimal)TotalPrice;
            return true;
        }
        else
        {
            totalPrice = 0;
            return false;
        }
    }
    public void ApplyDiscount(ref decimal price, decimal percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage), "Discount percentage must be between 0 and 100.");
        }
        price -= price * (percentage / 100);
    }
    
}