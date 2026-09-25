using System;

public static class ObjectInspector
{
    public static void Inspect(object obj)
    {
        if (obj == null)
        {
            Console.WriteLine("Object is null.");
            return;
        }

        var type = obj.GetType();
        Console.WriteLine($"Type: {type.FullName}");

        var props = type.GetProperties();
        foreach (var p in props)
        {
            object value;
            try { value = p.GetValue(obj); }
            catch { value = "<error reading>"; }
            Console.WriteLine($"{p.Name}: {value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();

        List<Customer> customers = new List<Customer>();
        List<Product> products = new List<Product>();
        List<Order> orders = new List<Order>();

        bool isRunning = true;

        do
        {
            Console.Clear();

            Console.WriteLine("========================================");
            Console.WriteLine("              SHOPHUB");
            Console.WriteLine("========================================");
            Console.WriteLine();
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Add Product");
            Console.WriteLine("3. Show Products");
            Console.WriteLine("4. Search Product");
            Console.WriteLine("5. Filter Products");
            Console.WriteLine("6. Create Order");
            Console.WriteLine("7. Add Product To Order");
            Console.WriteLine("8. Remove Product From Order");
            Console.WriteLine("9. Show Order");
            Console.WriteLine("10. Confirm Order");
            Console.WriteLine("11. Cancel Order");
            Console.WriteLine("12. Show Customer Orders");
            Console.WriteLine("13. Delete Product");
            Console.WriteLine("14. Restore Product");
            Console.WriteLine("15. Show Deleted Products");
            Console.WriteLine("16. Product Statistics");
            Console.WriteLine("17. Object Inspector");
            Console.WriteLine("18. Garbage Collection Test");
            Console.WriteLine("0. Exit");
            Console.WriteLine();

            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    // =========================
                    // 1. ADD CUSTOMER
                    // =========================
                    case "1":

                        Console.Write("Id: ");
                        int customerId = int.Parse(Console.ReadLine());

                        Console.Write("First Name: ");
                        string firstName = Console.ReadLine();

                        Console.Write("Last Name: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        string phone = Console.ReadLine();

                        Customer customer = new Customer
                        {
                            Id = customerId,
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            PhoneNumber = phone,
                            IsDeleted = false,
                            CreatedAt = DateTime.Now
                        };

                        customers.Add(customer);

                        Console.WriteLine();
                        Console.WriteLine(
                            $"Customer '{customer.FullName}' added successfully.");

                        break;


                    // =========================
                    // 2. ADD PRODUCT
                    // =========================
                    case "2":

                        Console.Write("Id: ");
                        int productId = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Description: ");
                        string description = Console.ReadLine();

                        Console.Write("Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Stock: ");
                        int stock = int.Parse(Console.ReadLine());

                        Console.WriteLine();
                        Console.WriteLine("0 - Electronics");
                        Console.WriteLine("1 - Books");
                        Console.WriteLine("2 - Clothing");
                        Console.WriteLine("3 - Food");

                        Console.Write("Category: ");
                        ProductCategory category =
                            (ProductCategory)int.Parse(Console.ReadLine());

                        Product product = new Product
                        {
                            Id = productId,
                            Name = name,
                            Description = description,
                            Price = price,
                            Stock = stock,
                            Category = category,
                            IsDeleted = false,
                            CreatedAt = DateTime.Now
                        };

                        products.Add(product);

                        productService.AddProduct(product);

                        break;


                    // =========================
                    // 3. SHOW PRODUCTS
                    // =========================
                    case "3":

                        productService.GetAllProducts();

                        break;


                    // =========================
                    // 4. SEARCH PRODUCT
                    // =========================
                    case "4":

                        Console.Write("Search keyword: ");
                        string keyword = Console.ReadLine();

                        productService.SearchProduct(keyword);

                        break;


                    // =========================
                    // 5. FILTER PRODUCTS
                    // =========================
                    case "5":

                        Console.WriteLine();
                        Console.WriteLine("1. Filter By Price");
                        Console.WriteLine("2. Filter By Category");
                        Console.WriteLine("3. Filter By Stock");

                        Console.Write("Choose: ");
                        string filterChoice = Console.ReadLine();

                        switch (filterChoice)
                        {
                            case "1":

                                Console.Write("Min price: ");
                                int min = int.Parse(Console.ReadLine());

                                Console.Write("Max price: ");
                                int max = int.Parse(Console.ReadLine());

                                productService.GetProductsByPrice(min, max);

                                break;

                            case "2":

                                Console.WriteLine("0 - Electronics");
                                Console.WriteLine("1 - Books");
                                Console.WriteLine("2 - Clothing");
                                Console.WriteLine("3 - Food");

                                Console.Write("Category: ");

                                ProductCategory selectedCategory =
                                    (ProductCategory)int.Parse(
                                        Console.ReadLine());

                                productService.GetProductsByCategory(
                                    selectedCategory);

                                break;

                            case "3":

                                Console.Write("Stock: ");
                                int selectedStock =
                                    int.Parse(Console.ReadLine());

                                productService.GetProductsByStock(
                                    selectedStock);

                                break;

                            default:

                                Console.WriteLine("Invalid choice.");

                                break;
                        }

                        break;


                    // =========================
                    // 6. CREATE ORDER
                    // =========================
                    case "6":

                        Console.Write("Order Id: ");
                        int orderId = int.Parse(Console.ReadLine());

                        Console.Write("Customer Id: ");
                        int selectedCustomerId =
                            int.Parse(Console.ReadLine());

                        Customer selectedCustomer =
                            customers.FirstOrDefault(
                                c => c.Id == selectedCustomerId);

                        if (selectedCustomer == null)
                        {
                            Console.WriteLine("Customer not found.");
                            break;
                        }

                        Order order = new Order
                        {
                            Id = orderId,
                            Customer = selectedCustomer,
                            OrderItems = new List<OrderItem>(),
                            Status = OrderStatus.Pending,
                            CreatedAt = DateTime.Now,
                            IsDeleted = false
                        };

                        orders.Add(order);

                        orderService.CreateOrder(order);

                        break;


                    // =========================
                    // 7. ADD PRODUCT TO ORDER
                    // =========================
                    case "7":

                        Console.Write("Order Id: ");
                        int addOrderId = int.Parse(Console.ReadLine());

                        Order selectedOrder =
                            orders.FirstOrDefault(
                                o => o.Id == addOrderId);

                        if (selectedOrder == null)
                        {
                            Console.WriteLine("Order not found.");
                            break;
                        }

                        Console.Write("Product Id: ");
                        int addProductId = int.Parse(Console.ReadLine());

                        Product selectedProduct =
                            products.FirstOrDefault(
                                p => p.Id == addProductId);

                        if (selectedProduct == null)
                        {
                            Console.WriteLine("Product not found.");
                            break;
                        }

                        Console.Write("Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        OrderItem orderItem = new OrderItem
                        {
                            Product = selectedProduct,
                            Quantity = quantity,
                            UnitPrice = selectedProduct.Price
                        };

                        // Yalnız service əlavə edir.
                        // İkinci dəfə Add etməmək üçün
                        // selectedOrder.OrderItems.Add() yazmırıq.

                        orderService.AddProdtuctToOrder(
                            addOrderId,
                            orderItem);

                        break;


                    // =========================
                    // 8. REMOVE PRODUCT
                    // =========================
                    case "8":

                        Console.Write("Order Id: ");
                        int removeOrderId =
                            int.Parse(Console.ReadLine());

                        Console.Write("Product Name: ");
                        string removeProductName =
                            Console.ReadLine();

                        orderService.RemoveProductFromOrder(
                            removeOrderId,
                            removeProductName);

                        break;


                    // =========================
                    // 9. SHOW ORDER
                    // =========================
                    case "9":

                        Console.Write("Order Id: ");
                        int showOrderId =
                            int.Parse(Console.ReadLine());

                        orderService.GetOrder(showOrderId);

                        break;


                    // =========================
                    // 10. CONFIRM ORDER
                    // =========================
                    case "10":

                        Console.Write("Order Id: ");
                        int confirmOrderId =
                            int.Parse(Console.ReadLine());

                        orderService.ConfirmOrder(confirmOrderId);

                        break;


                    // =========================
                    // 11. CANCEL ORDER
                    // =========================
                    case "11":

                        Console.Write("Order Id: ");
                        int cancelOrderId =
                            int.Parse(Console.ReadLine());

                        orderService.CancelOrder(cancelOrderId);

                        break;


                    // =========================
                    // 12. CUSTOMER ORDERS
                    // =========================
                    case "12":

                        Console.Write("Customer Id: ");
                        int customerOrdersId =
                            int.Parse(Console.ReadLine());

                        orderService.GetCustomerOrders(
                            customerOrdersId);

                        break;


                    // =========================
                    // 13. DELETE PRODUCT
                    // =========================
                    case "13":

                        Console.Write("Product Id: ");
                        int deleteProductId =
                            int.Parse(Console.ReadLine());

                        productService.RemoveProduct(
                            deleteProductId);

                        break;


                    // =========================
                    // 14. RESTORE PRODUCT
                    // =========================
                    case "14":

                        Console.Write("Product Id: ");
                        int restoreProductId =
                            int.Parse(Console.ReadLine());

                        productService.RestoreProduct(
                            restoreProductId);

                        break;


                    // =========================
                    // 15. SHOW DELETED PRODUCTS
                    // =========================
                    case "15":

                        var deletedProducts =
                            products
                            .Where(p => p.IsDeleted)
                            .ToList();

                        if (deletedProducts.Any())
                        {
                            Console.WriteLine(
                                "Deleted Products:");

                            foreach (var deletedProduct
                                     in deletedProducts)
                            {
                                Console.WriteLine(
                                    $"Id: {deletedProduct.Id}, " +
                                    $"Name: {deletedProduct.Name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine(
                                "No deleted products.");
                        }

                        break;


                    // =========================
                    // 16. PRODUCT STATISTICS
                    // =========================
                    case "16":

                        Console.WriteLine();
                        Console.WriteLine(
                            "1. Most Expensive Product");
                        Console.WriteLine(
                            "2. Cheapest Product");
                        Console.WriteLine(
                            "3. Available Products");
                        Console.WriteLine(
                            "4. Out Of Stock Products");
                        Console.WriteLine(
                            "5. Best Selling Product");

                        Console.Write("Choose: ");
                        string statisticChoice =
                            Console.ReadLine();

                        switch (statisticChoice)
                        {
                            case "1":

                                productService
                                    .GetMostExpensiveProduct();

                                break;

                            case "2":

                                productService
                                    .GetCheapestProduct();

                                break;

                            case "3":

                                productService
                                    .GetAvailableProducts();

                                break;

                            case "4":

                                productService
                                    .GetOutOfStockProducts();

                                break;

                            case "5":

                                productService
                                    .GetBestSellingProduct();

                                break;

                            default:

                                Console.WriteLine(
                                    "Invalid choice.");

                                break;
                        }

                        break;


                    // =========================
                    // 17. OBJECT INSPECTOR
                    // =========================
                    case "17":

                        if (products.Any())
                        {
                            Product firstProduct =
                                products.First();

                            ObjectInspector.Inspect(
                                firstProduct);
                        }
                        else
                        {
                            Console.WriteLine(
                                "No product available.");
                        }

                        break;


                    // =========================
                    // 18. GARBAGE COLLECTION
                    // =========================
                    case "18":

                        MemoryTest memoryTest =
                            new MemoryTest();

                        memoryTest.Test();

                        break;


                    // =========================
                    // 0. EXIT
                    // =========================
                    case "0":

                        isRunning = false;

                        Console.WriteLine(
                            "Program finished.");

                        break;


                    default:

                        Console.WriteLine(
                            "Invalid choice.");

                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(
                    "Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Error: {ex.Message}");
            }

            if (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Press any key to continue...");

                Console.ReadKey();
            }

        } while (isRunning);
    }
}