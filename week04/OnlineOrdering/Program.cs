using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create an address for a USA customer
        Address usaAddress = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer usaCustomer = new Customer("John Smith", usaAddress);

        // Create a list of products for the first order
        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", "LAP123", 1200.00m, 1),
            new Product("Mouse", "MOU456", 25.50m, 2)
        };
        Order order1 = new Order(products1, usaCustomer);

        // Display results for the first order
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Order Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine("\n----------------------------------------\n");

        // Create an address for a non-USA customer
        Address nonUsaAddress = new Address("456 International Ave", "Global City", "ON", "Canada");
        Customer nonUsaCustomer = new Customer("Jane Doe", nonUsaAddress);

        // Create a list of products for the second order
        List<Product> products2 = new List<Product>
        {
            new Product("Keyboard", "KEY789", 75.00m, 1),
            new Product("Monitor", "MON012", 250.00m, 1),
            new Product("Webcam", "WEB345", 50.00m, 3)
        };
        Order order2 = new Order(products2, nonUsaCustomer);

        // Display results for the second order
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Order Cost: ${order2.GetTotalCost():F2}");
    }
}