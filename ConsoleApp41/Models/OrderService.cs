public interface IOrderService
{
    void CreateOrder(Order order);
    void AddProdtuctToOrder(int orderId, OrderItem orderItem);
    void RemoveProductFromOrder(int orderId, string productName);
    void ConfirmOrder(int orderId);
    void CancelOrder(int orderId);
    void GetOrder(int orderId);
    void GetCustomerOrders(int customerId);

}
public class OrderService : IOrderService
{
    List<Order> orders = new List<Order>();
    public void CreateOrder(Order order)
    {
        orders.Add(order);
        Console.WriteLine($"Order with ID {order.Id} created successfully.");
    }
    public void AddProdtuctToOrder(int orderId, OrderItem orderItem)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.OrderItems.Add(orderItem);
            Console.WriteLine($"Product '{orderItem.Product}' added to order ID {orderId} successfully.");
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }
    public void RemoveProductFromOrder(int orderId, string productName)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            var orderItem = order.OrderItems.FirstOrDefault(
    oi => oi.Product.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (orderItem != null)
            {
                order.OrderItems.Remove(orderItem);
                Console.WriteLine($"Product '{productName}' removed from order ID {orderId} successfully.");
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found in order ID {orderId}.");
            }
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }
    public void ConfirmOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.Status = OrderStatus.Confirmed;
            Console.WriteLine($"Order ID {orderId} confirmed successfully.");
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }
    public void CancelOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            order.Status = OrderStatus.Cancelled;
            Console.WriteLine($"Order ID {orderId} canceled successfully.");
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }
    public void GetOrder(int orderId)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order != null)
        {
            Console.WriteLine($"Order ID: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.FullName}");
            Console.WriteLine($"Total Price: {order.TotalPrice}");
            Console.WriteLine($"Status: {order.Status}");
            Console.WriteLine($"Created At: {order.CreatedAt}");
            Console.WriteLine("Order Items:");
            foreach (var item in order.OrderItems)
            {
                Console.WriteLine($"- Product: {item.Product}, Quantity: {item.Quantity}, Total Price: {item.TotalPrice}");
            }
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }
    public void GetCustomerOrders(int customerId)
    {
        var customerOrders = orders.Where(o => o.Customer.Id == customerId).ToList();
        if (customerOrders.Any())
        {
            Console.WriteLine($"Orders for Customer ID {customerId}:");
            foreach (var order in customerOrders)
            {
                Console.WriteLine($"- Order ID: {order.Id}, Total Price: {order.TotalPrice}, Status: {order.Status}, Created At: {order.CreatedAt}");
            }
        }
        else
        {
            Console.WriteLine($"No orders found for Customer ID {customerId}.");
        }
    }


}