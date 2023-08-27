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
        while (true)
        {
            Console.WriteLine("Employee Management Menu:");
            Console.WriteLine("1. View Employees");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Back to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayEmployees(employeeService);
                    break;
                case "2":
                    AddEmployee(employeeService);
                    break;
                case "3":
                    UpdateEmployee(employeeService);
                    break;
                case "4":
                    DeleteEmployee(employeeService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void DisplayEmployees(EmployeeService employeeService)
    {
        IEnumerable<Employee> employees = employeeService.GetEmployees();

        Console.WriteLine("Employees:");
        foreach (Employee employee in employees)
        {
            Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}, Position: {employee.Position}, Phone: {employee.PhoneNumber}, Email: {employee.EmailAddress}");
        }
    }

    static void AddEmployee(EmployeeService employeeService)
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Position: ");
        string position = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter Email Address: ");
        string email = Console.ReadLine();

        Employee newEmployee = new Employee { Name = name, Position = position, PhoneNumber = phone, EmailAddress = email };
        employeeService.InsertEmployee(newEmployee);
        Console.WriteLine("Employee added successfully.");
    }

    static void UpdateEmployee(EmployeeService employeeService)
    {
        Console.Write("Enter Employee ID to update: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        Employee existingEmployee = employeeService.GetEmployees().FirstOrDefault(e => e.EmployeeId == employeeId);

        if (existingEmployee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write("Enter New Name: ");
        string newName = Console.ReadLine();

        Console.Write("Enter New Position: ");
        string newPosition = Console.ReadLine();

        Console.Write("Enter New Phone Number: ");
        string newPhone = Console.ReadLine();

        Console.Write("Enter New Email Address: ");
        string newEmail = Console.ReadLine();

        existingEmployee.Name = newName;
        existingEmployee.Position = newPosition;
        existingEmployee.PhoneNumber = newPhone;
        existingEmployee.EmailAddress = newEmail;

        employeeService.UpdateEmployee(existingEmployee);
        Console.WriteLine("Employee updated successfully.");
    }

    static void DeleteEmployee(EmployeeService employeeService)
    {
        Console.Write("Enter Employee ID to delete: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        employeeService.DeleteEmployee(employeeId);
        Console.WriteLine("Employee deleted successfully.");
    }

    static void ManageBills(BillService billService)
    {
        while (true)
        {
            Console.WriteLine("Bill Management Menu:");
            Console.WriteLine("1. View Bills");
            Console.WriteLine("2. Add Bill");
            Console.WriteLine("3. Update Bill");
            Console.WriteLine("4. Delete Bill");
            Console.WriteLine("5. Back to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayBills(billService);
                    break;
                case "2":
                    AddBill(billService);
                    break;
                case "3":
                    UpdateBill(billService);
                    break;
                case "4":
                    DeleteBill(billService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void DisplayBills(BillService billService)
    {
        IEnumerable<Bill> bills = billService.GetBills();

        Console.WriteLine("Bills:");
        foreach (Bill bill in bills)
        {
            Console.WriteLine($"ID: {bill.BillId}, Customer ID: {bill.CustomerId}, Employee ID: {bill.EmployeeId}, Total Amount: {bill.TotalAmount}");
        }
    }

    static void AddBill(BillService billService)
    {
        Console.Write("Enter Customer ID: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee ID: ");
        int employeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Total Amount: ");
        decimal totalAmount = Convert.ToDecimal(Console.ReadLine());

        Bill newBill = new Bill { CustomerId = customerId, EmployeeId = employeeId, TotalAmount = totalAmount };
        billService.InsertBill(newBill);
        Console.WriteLine("Bill added successfully.");
    }

    static void UpdateBill(BillService billService)
    {
        Console.Write("Enter Bill ID to update: ");
        int billId = Convert.ToInt32(Console.ReadLine());

        Bill existingBill = billService.GetBills().FirstOrDefault(b => b.BillId == billId);

        if (existingBill == null)
        {
            Console.WriteLine("Bill not found.");
            return;
        }

        Console.Write("Enter New Customer ID: ");
        int newCustomerId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Employee ID: ");
        int newEmployeeId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Total Amount: ");
        decimal newTotalAmount = Convert.ToDecimal(Console.ReadLine());

        existingBill.CustomerId = newCustomerId;
        existingBill.EmployeeId = newEmployeeId;
        existingBill.TotalAmount = newTotalAmount;

        billService.UpdateBill(existingBill);
        Console.WriteLine("Bill updated successfully.");
    }

    static void DeleteBill(BillService billService)
    {
        Console.Write("Enter Bill ID to delete: ");
        int billId = Convert.ToInt32(Console.ReadLine());

        billService.DeleteBill(billId);
        Console.WriteLine("Bill deleted successfully.");
    }

    static void ManageOrders(OrderService orderService)
    {
        while (true)
        {
            Console.WriteLine("Order Management Menu:");
            Console.WriteLine("1. View Orders");
            Console.WriteLine("2. Add Order");
            Console.WriteLine("3. Update Order");
            Console.WriteLine("4. Delete Order");
            Console.WriteLine("5. Back to Main Menu");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayOrders(orderService);
                    break;
                case "2":
                    AddOrder(orderService);
                    break;
                case "3":
                    UpdateOrder(orderService);
                    break;
                case "4":
                    DeleteOrder(orderService);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }

    static void DisplayOrders(OrderService orderService)
    {
        IEnumerable<Order> orders = orderService.GetOrders();

        Console.WriteLine("Orders:");
        foreach (Order order in orders)
        {
            Console.WriteLine($"ID: {order.OrderId}, Bill ID: {order.BillId}, Item ID: {order.ItemId}, Item Type: {order.ItemType}, Quantity: {order.Quantity}");
        }
    }

    static void AddOrder(OrderService orderService)
    {
        Console.Write("Enter Bill ID: ");
        int billId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Item ID: ");
        int itemId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Item Type: ");
        string itemType = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        
        int quantity = Convert.ToInt32(Console.ReadLine());

        Order newOrder = new Order { BillId = billId, ItemId = itemId, ItemType = itemType, Quantity = quantity };
        orderService.InsertOrder(newOrder);
        Console.WriteLine("Order added successfully.");
    }

    static void UpdateOrder(OrderService orderService)
    {
        Console.Write("Enter Order ID to update: ");
        int orderId = Convert.ToInt32(Console.ReadLine());

        Order existingOrder = orderService.GetOrders().FirstOrDefault(o => o.OrderId == orderId);

        if (existingOrder == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        Console.Write("Enter New Bill ID: ");
        int newBillId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Item ID: ");
        int newItemId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter New Item Type: ");
        string newItemType = Console.ReadLine();

        Console.Write("Enter New Quantity: ");
        int newQuantity = Convert.ToInt32(Console.ReadLine());

        existingOrder.BillId = newBillId;
        existingOrder.ItemId = newItemId;
        existingOrder.ItemType = newItemType;
        existingOrder.Quantity = newQuantity;

        orderService.UpdateOrder(existingOrder);
        Console.WriteLine("Order updated successfully.");
    }

    static void DeleteOrder(OrderService orderService)
    {
        Console.Write("Enter Order ID to delete: ");
        int orderId = Convert.ToInt32(Console.ReadLine());

        orderService.DeleteOrder(orderId);
        Console.WriteLine("Order deleted successfully.");
    }
}