using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarProject.Models;

namespace BarProject.Database_access
{
    public class DatabaseAccess
    {
        private readonly string _connectionString;

        public DatabaseAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM customers", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            CustomerId = Convert.ToInt32(reader["Customer_id"]),
                            Name = reader["Name"].ToString(),
                            PhoneNumber = reader["Phone_number"].ToString(),
                            EmailAddress = reader["Email_address"].ToString()
                        };
                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }
        public IEnumerable<Customer> GetCustomersWithStoredProc()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Customer customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(reader["Customer_id"]),
                                Name = reader["Name"].ToString(),
                                PhoneNumber = reader["Phone_number"].ToString(),
                                EmailAddress = reader["Email_address"].ToString()
                            };
                            customers.Add(customer);
                        }
                    }
                }
            }

            return customers;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM employees", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                            Name = reader["Name"].ToString(),
                            Position = reader["Position"].ToString(),
                            PhoneNumber = reader["Phone_number"].ToString(),
                            EmailAddress = reader["Email_address"].ToString()
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }
        public IEnumerable<Employee> GetEmployeesWithStoredProc()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                                Name = reader["Name"].ToString(),
                                Position = reader["Position"].ToString(),
                                PhoneNumber = reader["Phone_number"].ToString(),
                                EmailAddress = reader["Email_address"].ToString()
                            };
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
        public IEnumerable<Bill> GetBills()
        {
            List<Bill> bills = new List<Bill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM bills", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bill bill = new Bill
                        {
                            BillId = Convert.ToInt32(reader["Bill_id"]),
                            CustomerId = Convert.ToInt32(reader["Customer_id"]),
                            EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                            TotalAmount = Convert.ToInt32(reader["Total_amount"])
                        };
                        bills.Add(bill);
                    }
                }
            }

            return bills;
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM orders", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderId = Convert.ToInt32(reader["Order_id"]),
                            BillId = Convert.ToInt32(reader["Bill_id"]),
                            ItemId = Convert.ToInt32(reader["Item_id"]),
                            ItemType = reader["Item_type"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };
                        orders.Add(order);
                    }
                }
            }

            return orders;
        }
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE customers " +
                                     "SET Name = @Name, Phone_number = @PhoneNumber, Email_address = @EmailAddress " +
                                     "WHERE Customer_id = @CustomerId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating customer: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO customers (Customer_id, Name, Phone_number, Email_address) " +
                                     "VALUES (@CustomerId, @Name, @PhoneNumber, @EmailAddress)";

                // Query to get the highest existing Customer_id
                string maxIdQuery = "SELECT MAX(Customer_id) FROM customers";

                int newCustomerId;

                using (SqlCommand command = new SqlCommand(maxIdQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newCustomerId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newCustomerId = 1; // Start from 1 if no records exist
                    }
                }


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", newCustomerId);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailAddress", customer.EmailAddress);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting customer: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Query to get the highest existing Employee_id
                string maxIdQuery = "SELECT MAX(Employee_id) FROM employees";
                int newEmployeeId;

                using (SqlCommand maxIdCommand = new SqlCommand(maxIdQuery, connection))
                {
                    object result = maxIdCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newEmployeeId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newEmployeeId = 1; // Start from 1 if no records exist
                    }
                }

                string insertQuery = "INSERT INTO employees (Employee_id, Name, Position, Phone_number, Email_address) " +
                                     "VALUES (@EmployeeId, @Name, @Position, @PhoneNumber, @EmailAddress)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", newEmployeeId);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting employee: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM employees WHERE Employee_id = @EmployeeId";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting employee: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE employees " +
                                     "SET Name = @Name, Position = @Position, Phone_number = @PhoneNumber, Email_address = @EmailAddress " +
                                     "WHERE Employee_id = @EmployeeId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating employee: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void InsertBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Query to get the highest existing Bill_id
                string maxIdQuery = "SELECT MAX(Bill_id) FROM bills";
                int newBillId;

                using (SqlCommand command = new SqlCommand(maxIdQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newBillId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newBillId = 1; // Start from 1 if no records exist
                    }
                }

                string insertQuery = "INSERT INTO bills (Bill_id, Customer_id, Employee_id, Total_amount) " +
                                     "VALUES (@BillId, @CustomerId, @EmployeeId, @TotalAmount)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@BillId", newBillId);
                    command.Parameters.AddWithValue("@CustomerId", bill.CustomerId);
                    command.Parameters.AddWithValue("@EmployeeId", bill.EmployeeId);
                    command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting bill: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void InsertOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Query to get the highest existing Order_id
                string maxIdQuery = "SELECT MAX(Order_id) FROM orders";
                int newOrderId;

                using (SqlCommand command = new SqlCommand(maxIdQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newOrderId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newOrderId = 1; // Start from 1 if no records exist
                    }
                }

                string insertQuery = "INSERT INTO orders (Order_id, Bill_id, Item_id, Item_type, Quantity) " +
                                     "VALUES (@OrderId, @BillId, @ItemId, @ItemType, @Quantity)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", newOrderId);
                    command.Parameters.AddWithValue("@BillId", order.BillId);
                    command.Parameters.AddWithValue("@ItemId", order.ItemId);
                    command.Parameters.AddWithValue("@ItemType", order.ItemType);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting order: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM orders WHERE Order_id = @OrderId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting order: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void DeleteBill(int billId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM bills WHERE Bill_id = @BillId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@BillId", billId);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting bill: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void UpdateBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE bills " +
                                     "SET Customer_id = @CustomerId, Employee_id = @EmployeeId, Total_amount = @TotalAmount " +
                                     "WHERE Bill_id = @BillId";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@BillId", bill.BillId);
                    command.Parameters.AddWithValue("@CustomerId", bill.CustomerId);
                    command.Parameters.AddWithValue("@EmployeeId", bill.EmployeeId);
                    command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating bill: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE orders " +
                                     "SET Bill_id = @BillId, Item_id = @ItemId, Item_type = @ItemType, Quantity = @Quantity " +
                                     "WHERE Order_id = @OrderId";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", order.OrderId);
                    command.Parameters.AddWithValue("@BillId", order.BillId);
                    command.Parameters.AddWithValue("@ItemId", order.ItemId);
                    command.Parameters.AddWithValue("@ItemType", order.ItemType);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating order: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        
        public List<Bill> GetBillsByCustomer(int customerId)
        {
            List<Bill> bills = new List<Bill>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM bills WHERE Customer_id = @CustomerId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Bill bill = new Bill();
                            bill.BillId = reader.GetInt32(0);
                            bill.CustomerId = reader.GetInt32(1);
                            bill.EmployeeId = reader.GetInt32(2);
                            bill.TotalAmount = reader.GetDecimal(3);
                            bills.Add(bill);
                        }
                    }
                }
            }
            return bills;
        }
        public List<Order> GetOrdersByBill(int billId)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM orders WHERE Bill_id = @BillId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@BillId", billId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = reader.GetInt32(0);
                            order.BillId = reader.GetInt32(1);
                            order.ItemId = reader.GetInt32(2);
                            order.ItemType = reader.GetString(3);
                            order.Quantity = reader.GetInt32(4);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }   

        public List<Order> GetOrdersByCustomer(int customerId)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM orders WHERE Bill_id IN (SELECT Bill_id FROM bills WHERE Customer_id = @CustomerId)";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = reader.GetInt32(0);
                            order.BillId = reader.GetInt32(1);
                            order.ItemId = reader.GetInt32(2);
                            order.ItemType = reader.GetString(3);
                            order.Quantity = reader.GetInt32(4);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;  
        }
        public List<Order> GetOrdersByEmployee(int employeeId)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM orders WHERE Bill_id IN (SELECT Bill_id FROM bills WHERE Employee_id = @EmployeeId)";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = reader.GetInt32(0);
                            order.BillId = reader.GetInt32(1);
                            order.ItemId = reader.GetInt32(2);
                            order.ItemType = reader.GetString(3);
                            order.Quantity = reader.GetInt32(4);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }
        public List<Order> GetOrdersByItem(int itemId)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM orders WHERE Item_id = @ItemId";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ItemId", itemId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = reader.GetInt32(0);
                            order.BillId = reader.GetInt32(1);
                            order.ItemId = reader.GetInt32(2);
                            order.ItemType = reader.GetString(3);
                            order.Quantity = reader.GetInt32(4);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }
        public List<Order> GetOrdersByItemType(string itemType)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM orders WHERE Item_type = @ItemType";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ItemType", itemType);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.OrderId = reader.GetInt32(0);
                            order.BillId = reader.GetInt32(1);
                            order.ItemId = reader.GetInt32(2);
                            order.ItemType = reader.GetString(3);
                            order.Quantity = reader.GetInt32(4);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }
        public void DeleteCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM customers WHERE Customer_id = @CustomerId";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting customer: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void InsertTable(Table table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO tables (Table_id, Number, Capacity, Customer_id) " +
                                     "VALUES (@TableId, @Number, @Capacity, @CustomerId)";

                // Query to get the highest existing Table_id
                string maxIdQuery = "SELECT MAX(Table_id) FROM tables";

                int newTableId;

                using (SqlCommand command = new SqlCommand(maxIdQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        newTableId = Convert.ToInt32(result) + 1;
                    }
                    else
                    {
                        newTableId = 1; // Start from 1 if no records exist
                    }
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@TableId", newTableId);
                    command.Parameters.AddWithValue("@Number", table.Number);
                    command.Parameters.AddWithValue("@Capacity", table.Capacity);
                    command.Parameters.AddWithValue("@CustomerId", table.CustomerId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting table: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void UpdateTable(Table table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE tables " +
                                     "SET Number = @Number, Capacity = @Capacity, Customer_id = @CustomerId " +
                                     "WHERE Table_id = @TableId";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@TableId", table.TableId);
                    command.Parameters.AddWithValue("@Number", table.Number);
                    command.Parameters.AddWithValue("@Capacity", table.Capacity);
                    command.Parameters.AddWithValue("@CustomerId", table.CustomerId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error updating table: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void DeleteTable(int tableId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM tables WHERE Table_id = @TableId";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@TableId", tableId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting table: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public IEnumerable<Table> GetTables()
        {
            List<Table> tables = new List<Table>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM tables", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Table table = new Table
                        {
                            TableId = Convert.ToInt32(reader["Table_id"]),
                            Number = Convert.ToInt32(reader["Number"]),
                            Capacity = Convert.ToInt32(reader["Capacity"]),
                            CustomerId = reader["Customer_id"] != DBNull.Value ? Convert.ToInt32(reader["Customer_id"]) : (int?)null
                        };
                        tables.Add(table);
                    }
                }
            }

            return tables;
        }
        public IEnumerable<EmployeeBill> GetEmployeeBills()
        {
            List<EmployeeBill> employeeBills = new List<EmployeeBill>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM employees_bills", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeBill employeeBill = new EmployeeBill
                        {
                            EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                            BillId = Convert.ToInt32(reader["Bill_id"])
                        };
                        employeeBills.Add(employeeBill);
                    }
                }
            }

            return employeeBills;
        }
        public void DeleteEmployeeBill(int employeeId, int billId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM employees_bills WHERE Employee_id = @EmployeeId AND Bill_id = @BillId";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.Parameters.AddWithValue("@BillId", billId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting employee-bill association: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void InsertEmployeeBill(EmployeeBill employeeBill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO employees_bills (Employee_id, Bill_id) " +
                                     "VALUES (@EmployeeId, @BillId)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeBill.EmployeeId);
                    command.Parameters.AddWithValue("@BillId", employeeBill.BillId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting employee-bill association: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void UpdateEmployeeBill(EmployeeBill employeeBill)
        {
            // To "update" an employee-bill association, we'll first delete the existing one
            DeleteEmployeeBill(employeeBill.EmployeeId, employeeBill.BillId);

            // Then, insert the updated association
            InsertEmployeeBill(employeeBill);
        }
        public IEnumerable<CustomerSitAt> GetCustomerSitAts()
        {
            List<CustomerSitAt> customerSitAts = new List<CustomerSitAt>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM customers_sit_at", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerSitAt customerSitAt = new CustomerSitAt
                        {
                            CustomerId = Convert.ToInt32(reader["Customer_id"]),
                            TableId = Convert.ToInt32(reader["Table_id"])
                        };
                        customerSitAts.Add(customerSitAt);
                    }
                }
            }

            return customerSitAts;
        }

        public void DeleteCustomerSitAt(int customerId, int tableId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM customers_sit_at WHERE Customer_id = @CustomerId AND Table_id = @TableId";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@TableId", tableId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error deleting customer-sit-at association: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void InsertCustomerSitAt(CustomerSitAt customerSitAt)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO customers_sit_at (Customer_id, Table_id) " +
                                     "VALUES (@CustomerId, @TableId)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerSitAt.CustomerId);
                    command.Parameters.AddWithValue("@TableId", customerSitAt.TableId);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error inserting customer-sit-at association: " + ex.Message);
                        throw;
                    }
                }
            }
        }

        public void UpdateCustomerSitAt(CustomerSitAt customerSitAt)
        {
            // To "update" a customer-sit-at association, we'll first delete the existing one
            DeleteCustomerSitAt(customerSitAt.CustomerId, customerSitAt.TableId);

            // Then, insert the updated association
            InsertCustomerSitAt(customerSitAt);
        }

    }
}
