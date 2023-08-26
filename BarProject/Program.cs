using BarProject.Database_access;
using BarProject.Models;
using BarProject.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Replace with your actual connection string
        string connectionString = "Server=DESKTOP-VF538LC;Database=Bar;Trusted_Connection=True;";

        DatabaseAccess databaseAccess = new DatabaseAccess(connectionString);
        CustomerService customerService = new CustomerService(databaseAccess);
        EmployeeService employeeService = new EmployeeService(databaseAccess);
        BillService billService = new BillService(databaseAccess);
        OrderService orderService = new OrderService(databaseAccess);

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Manage Customers");
            Console.WriteLine("2. Manage Employees");
            Console.WriteLine("3. Manage Bills");
            Console.WriteLine("4. Manage Orders");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageCustomers(customerService);
                    break;
                case "2":
                    ManageEmployees(employeeService);
                    break;
                case "3":
                    ManageBills(billService);
                    break;
                case "4":
                    ManageOrders(orderService);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void ManageCustomers(CustomerService customerService)
    {
        while (true)
        {
            Console.WriteLine("Customer Management Menu:");
            Console.WriteLine("1. View Customers");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Update Customer");
            Console.WriteLine("4. Delete Customer");
            Console.WriteLine("5. Back to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayCustomers(customerService);
                    break;
                case "2":
                    AddCustomer(customerService);
                    break;
                case "3":
                    UpdateCustomer(customerService);
                    break;
                case "4":
                    DeleteCustomer(customerService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void DisplayCustomers(CustomerService customerService)
    {
        IEnumerable<Customer> customers = customerService.GetCustomers();

        Console.WriteLine("Customers:");
        foreach (Customer customer in customers)
        {
            Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Phone: {customer.PhoneNumber}, Email: {customer.EmailAddress}");
        }
    }

    static void AddCustomer(CustomerService customerService)
    {
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Email Address: ");
        string email = Console.ReadLine();

        Customer newCustomer = new Customer { Name = name, PhoneNumber = phone, EmailAddress = email };
        customerService.InsertCustomer(newCustomer);
        Console.WriteLine("Customer added successfully.");
    }

    static void UpdateCustomer(CustomerService customerService)
    {
        Console.Write("Enter Customer ID to update: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Customer existingCustomer = customerService.GetCustomers().FirstOrDefault(c => c.CustomerId == customerId);

        if (existingCustomer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Console.Write("Enter New Name: ");
        string newName = Console.ReadLine();

        Console.Write("Enter New Phone Number: ");
        string newPhone = Console.ReadLine();

        Console.Write("Enter New Email Address: ");
        string newEmail = Console.ReadLine();

        existingCustomer.Name = newName;
        existingCustomer.PhoneNumber = newPhone;
        existingCustomer.EmailAddress = newEmail;

        customerService.UpdateCustomer(existingCustomer);
        Console.WriteLine("Customer updated successfully.");
    }

    static void DeleteCustomer(CustomerService customerService)
    {
        Console.Write("Enter Customer ID to delete: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        customerService.DeleteCustomer(customerId);
        Console.WriteLine("Customer deleted successfully.");
    }

    static void ManageEmployees(EmployeeService employeeService)
    {
        // Implement employee management options here
        // You can include options for viewing, adding, updating, and deleting employees
    }

    static void ManageBills(BillService billService)
    {
        // Implement bill management options here
        // You can include options for viewing, adding, updating, and deleting bills
    }

    static void ManageOrders(OrderService orderService)
    {
        // Implement order management options here
        // You can include options for viewing, adding, updating, and deleting orders
    }
}