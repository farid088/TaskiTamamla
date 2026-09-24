public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public double TotalPrice => OrderItems.Sum(item => item.TotalPrice);
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt{ get; set; }
    public bool IsDeleted { get; set; }
    
}