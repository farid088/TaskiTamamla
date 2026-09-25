public interface IProductService
{
    void AddProduct(Product product);
    void RemoveProduct(int productId); 
    void RestoreProduct(int productId);
    void GetProduct(int productId);
    void GetAllProducts();
    void SearchProduct(string keyword);
  
}

public class ProductService : IProductService
{
    List<Customer> customers = new List<Customer>();
    List<Order> orders = new List<Order>();
    List<OrderItem> orderItems = new List<OrderItem>();
    List<Product> products = new List<Product>();
    public void SearchProduct(string keyword)
    {
        var results = products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) || p.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        Console.WriteLine($"Search results for '{keyword}':");
        foreach (var product in results)
        {
            product.GetProductInfo();
        }
    }
    public void AddProduct(Product product)
    {
        products.Add(product);
        Console.WriteLine($"Product '{product.Name}' added successfully.");
    }
    public void RemoveProduct(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.IsDeleted = true;
            Console.WriteLine($"Product '{product.Name}' removed successfully.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
    public void RestoreProduct(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.IsDeleted = false;
            Console.WriteLine($"Product '{product.Name}' restored successfully.");
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
    public void GetProduct(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            product.GetProductInfo();
        }
        else
        {
            Console.WriteLine($"Product with ID {productId} not found.");
        }
    }
    public void GetAllProducts()
    {
        foreach (var product in products)
        {
            product.GetProductInfo();
        }
    }
    public void GetMostExpensiveProduct()
    {
        var mostExpensiveProduct = products.OrderByDescending(p => p.Price).FirstOrDefault();
        if (mostExpensiveProduct != null)
        {
            Console.WriteLine("Most expensive product:");
            mostExpensiveProduct.GetProductInfo();
        }
        else
        {
            Console.WriteLine("No products available.");
        }
    }
    public void GetCheapestProduct()
    {
        var cheapestProduct = products.OrderBy(p => p.Price).FirstOrDefault();
        if (cheapestProduct != null)
        {
            Console.WriteLine("Cheapest product:");
            cheapestProduct.GetProductInfo();
        }
        else
        {
            Console.WriteLine("No products available.");
        }
    }
    public void GetAvailableProducts()
    {
        var availableProducts = products.Where(p => p.Stock > 0 && !p.IsDeleted).ToList();
        if (availableProducts.Any())
        {
            Console.WriteLine("Available products:");
            foreach (var product in availableProducts)
            {
                product.GetProductInfo();
            }
        }
        else
        {
            Console.WriteLine("No available products.");
        }
    }
    public void GetOutOfStockProducts()
    {
        var outOfStockProducts = products.Where(p => p.Stock == 0 && !p.IsDeleted).ToList();
        if (outOfStockProducts.Any())
        {
            Console.WriteLine("Out of stock products:");
            foreach (var product in outOfStockProducts)
            {
                product.GetProductInfo();
            }
        }
        else
        {
            Console.WriteLine("No out of stock products.");
        }
    }
    public void GetProductsByPrice(int min, int max)
    {
        var productsByPrice = products.Where(p => p.Price >= min && p.Price <= max && !p.IsDeleted).ToList();
        if (productsByPrice.Any())
        {
            Console.WriteLine($"Products with price between {min} and {max}:");
            foreach (var product in productsByPrice)
            {
                product.GetProductInfo();
            }
        }
        else
        {
            Console.WriteLine($"No products found with price between {min} and {max}.");
        }
    }
    public void GetProductsByCategory(ProductCategory category)
    {
        var productsByCategory = products.Where(p => p.Category == category && !p.IsDeleted).ToList();
        if (productsByCategory.Any())
        {
            Console.WriteLine($"Products in category '{category}':");
            foreach (var product in productsByCategory)
            {
                product.GetProductInfo();
            }
        }
        else
        {
            Console.WriteLine($"No products found in category '{category}'.");
        }
    }
    public void GetProductsByStock(int stock)
    {
        var productsByStock = products.Where(p => p.Stock == stock && !p.IsDeleted).ToList();
        if (productsByStock.Any())
        {
            Console.WriteLine($"Products with stock {stock}:");
            foreach (var product in productsByStock)
            {
                product.GetProductInfo();
            }
        }
        else
        {
            Console.WriteLine($"No products found with stock {stock}.");
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
    public void GetBestSellingProduct()
    {
        var bestSellingProduct = orderItems
            .GroupBy(oi => oi.Product)
            .Select(g => new { Product = g.Key, TotalQuantity = g.Sum(oi => oi.Quantity) })
            .OrderByDescending(p => p.TotalQuantity)
            .FirstOrDefault();
        if (bestSellingProduct != null)
        {
            Console.WriteLine("Best selling product:");
            bestSellingProduct.Product.GetProductInfo();
            Console.WriteLine($"Total Quantity Sold: {bestSellingProduct.TotalQuantity}");
        }
        else
        {
            Console.WriteLine("No sales data available.");
        }
    }

}

