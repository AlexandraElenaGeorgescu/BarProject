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

                    command.ExecuteNonQuery();
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

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO employees (Name, Position, Phone_number, Email_address) " +
                                     "VALUES (@Name, @Position, @PhoneNumber, @EmailAddress)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Position", employee.Position);
                    command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    command.Parameters.AddWithValue("@EmailAddress", employee.EmailAddress);

                    command.ExecuteNonQuery();
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

                    command.ExecuteNonQuery();
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

                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO bills (Customer_id, Employee_id, Total_amount) " +
                                     "VALUES (@CustomerId, @EmployeeId, @TotalAmount)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", bill.CustomerId);
                    command.Parameters.AddWithValue("@EmployeeId", bill.EmployeeId);
                    command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void InsertOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO orders (Bill_id, Item_id, Item_type, Quantity) " +
                                     "VALUES (@BillId, @ItemId, @ItemType, @Quantity)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@BillId", order.BillId);
                    command.Parameters.AddWithValue("@ItemId", order.ItemId);
                    command.Parameters.AddWithValue("@ItemType", order.ItemType);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);
                    command.ExecuteNonQuery();
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
                    command.ExecuteNonQuery();
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
                    command.ExecuteNonQuery();
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
                    command.ExecuteNonQuery();
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
                    command.ExecuteNonQuery();
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
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
