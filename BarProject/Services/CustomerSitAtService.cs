using BarProject.Database_access;
using BarProject.Models;
using System;
using System.Collections.Generic;

namespace BarProject.Services
{
    public class CustomerSitAtService
    {
        private readonly DatabaseAccess _databaseAccess;

        public CustomerSitAtService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<CustomerSitAt> GetCustomerSittings()
        {
            return _databaseAccess.GetCustomerSitAts();
        }

        public void InsertCustomerSitAt(CustomerSitAt customerSitAt)
        {
            _databaseAccess.InsertCustomerSitAt(customerSitAt);
        }

        public void UpdateCustomerSitAt(CustomerSitAt customerSitAt)
        {
            _databaseAccess.UpdateCustomerSitAt(customerSitAt);
        }

        public void DeleteCustomerSitAt(int customerId, int tableId)
        {
            _databaseAccess.DeleteCustomerSitAt(customerId, tableId);
        }
    }
}