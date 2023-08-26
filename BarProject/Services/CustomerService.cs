using BarProject.Database_access;
using BarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Services
{
    public class CustomerService
    {
        private readonly DatabaseAccess _databaseAccess;

        public CustomerService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _databaseAccess.GetCustomers();
        }
        public void InsertCustomer(Customer customer)
        {
            _databaseAccess.InsertCustomer(customer);
        }
        public void UpdateCustomer(Customer customer)
        {
            _databaseAccess.UpdateCustomer(customer);
        }
        public void DeleteCustomer(int customerId)
        {
            _databaseAccess.DeleteCustomer(customerId);
        }
    }
}
