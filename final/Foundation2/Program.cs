using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "CityA", "StateA", "USA");
        Address address2 = new Address("456 Elm St", "CityB", "StateB", "Canada");

        // Create customers
        Customer customer1 = new Customer("CustomerA", address1);
        Customer customer2 = new Customer("CustomerB", address2);

        // Create products
        Product product1 = new Product("Product1", "P001", 10.99, 3);
        Product product2 = new Product("Product2", "P002", 5.49, 5);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product1);

        // Display order information
        DisplayOrderInformation(order1);
        DisplayOrderInformation(order2);
    }

    static void DisplayOrderInformation(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine("Total Price: $" + order.GetTotalPrice());
        Console.WriteLine();
    }
}

class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        total += customer.IsInUSA() ? 5.0 : 35.0;

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"Name: {product.Name}, Product ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Customer: {customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}

class Product
{
    private string name;
    private string productId;
    private double pricePerUnit;
    private int quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.pricePerUnit = pricePerUnit;
        this.quantity = quantity;
    }

    public double GetTotalCost()
    {
        return pricePerUnit * quantity;
    }

    public string Name { get { return name; } }
    public string ProductId { get { return productId; } }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string Name { get { return name; } }
    public Address Address { get { return address; } }
}

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}
