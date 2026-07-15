using System;

class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: Domestic Customer ---
        Address address1 = new Address("456 College Ave", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("Elysian Smith", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "WM-01", 25.50, 1));
        order1.AddProduct(new Product("Mechanical Keyboard", "MK-88", 89.99, 1));
        order1.AddProduct(new Product("Mousepad", "MP-05", 12.00, 2));

        // --- Order 2: International Customer ---
        Address address2 = new Address("Calle Principal", "San Salvador", "San Salvador", "El Salvador");
        Customer customer2 = new Customer("Josue Aguilar", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Laptop Stand", "LS-22", 45.00, 1));
        order2.AddProduct(new Product("USB-C Hub", "UH-09", 35.75, 1));

        // --- Display Results ---
        Order[] orders = { order1, order2 };
        int orderNumber = 1;

        foreach (Order order in orders)
        {
            Console.WriteLine($"=== ORDER #{orderNumber} ===");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            
            Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalCost():F2}");
            Console.WriteLine(new string('=', 30));
            Console.WriteLine();
            orderNumber++;
        }
    }
}