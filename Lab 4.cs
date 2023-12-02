using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabWork.Lab 1
{
    public class Lab 4
    {
        using System;
using System.Collections.Generic;
using System.Linq;

interface ISearchable
{
    List<Product> SearchByPriceRange(double minPrice, double maxPrice);
    List<Product> SearchByCategory(string category);
    List<Product> SearchByRating(int minRating);
}

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Rating { get; set; }
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Order> PurchaseHistory { get; set; } = new List<Order>();
}

class Order
{
    public List<Product> Products { get; set; } = new List<Product>();
    public int Quantity { get; set; }
    public double TotalPrice => Products.Sum(product => product.Price * Quantity);
    public OrderStatus Status { get; set; }
}

enum OrderStatus
{
    Pending,
    Shipped,
    Delivered
}

class Store : ISearchable
{
    private List<Product> products = new List<Product>();
    private List<User> users = new List<User>();
    private List<Order> orders = new List<Order>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void DisplayProducts()
    {
        Console.WriteLine("Available Products:");
        foreach (var product in products)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Category: {product.Category}, Rating: {product.Rating}");
        }
        Console.WriteLine();
    }

    public void DisplayOrders()
    {
        Console.WriteLine("Orders:");
        foreach (var order in orders)
        {
            Console.WriteLine($"Total Price: {order.TotalPrice}, Status: {order.Status}");
        }
        Console.WriteLine();
    }

    public void PlaceOrder(User user, List<Product> selectedProducts, int quantity)
    {
        var order = new Order { Products = selectedProducts, Quantity = quantity, Status = OrderStatus.Pending };
        user.PurchaseHistory.Add(order);
        orders.Add(order);
        Console.WriteLine("Order placed successfully!");
    }

    public List<Product> SearchByPriceRange(double minPrice, double maxPrice)
    {
        return products.Where(product => product.Price >= minPrice && product.Price <= maxPrice).ToList();
    }

    public List<Product> SearchByCategory(string category)
    {
        return products.Where(product => product.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Product> SearchByRating(int minRating)
    {
        return products.Where(product => product.Rating >= minRating).ToList();
    }
}

class Program
{
    static void Main()
    {
        Store store = new Store();

        // Adding products to the store
        store.AddProduct(new Product { Name = "Laptop", Price = 1000, Category = "Electronics", Rating = 4 });
        store.AddProduct(new Product { Name = "Smartphone", Price = 500, Category = "Electronics", Rating = 5 });
        store.AddProduct(new Product { Name = "Book", Price = 20, Category = "Books", Rating = 4 });
        store.AddProduct(new Product { Name = "Chair", Price = 50, Category = "Furniture", Rating = 3 });

        // Adding users to the store
        store.AddUser(new User { Username = "user1", Password = "password1" });
        store.AddUser(new User { Username = "user2", Password = "password2" });

        // Displaying available products
        store.DisplayProducts();

        // Simulating user actions
        User currentUser = store.SearchUser("user1", "password1");
        if (currentUser != null)
        {
            Console.WriteLine($"Logged in as {currentUser.Username}");
            List<Product> selectedProducts = store.SearchByCategory("Electronics");
            store.DisplayProducts();

            // Placing an order
            store.PlaceOrder(currentUser, selectedProducts, 2);
            store.DisplayOrders();
        }
    }
}

    }
}
