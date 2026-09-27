using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "Provo",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "Joseph Smith",
            address1
        );

        Product product1 = new Product(
            "Air Fryer",
            "P001",
            600,
            3
        );

        Product product2 = new Product(
            "Washing Machine",
            "P002",
            1000,
            1
        );

        Product product3 = new Product(
            "Wall Mirror",
            "P003",
            100,
            4
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order1.GetTotalCost():F2}");

        Console.WriteLine();
        Console.WriteLine("--------------------------------");
        Console.WriteLine();

        // Order 2
        Address address2 = new Address(
            "Municipal Assembly Avenue",
            "Goaso",
            "Ahafo",
            "Ghana"
        );

        Customer customer2 = new Customer(
            "Pricilla Sarpong",
            address2
        );

        Product product4 = new Product(
            "Queen Size Mattress",
            "P004",
            1500,
            1
        );

        Product product5 = new Product(
            "Pwower Bank",
            "P005",
            50,
            5
        );

        Product product6 = new Product(
            "Nail Set",
            "P006",
            30,
            10
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order2.GetTotalCost():F2}");
    }
}