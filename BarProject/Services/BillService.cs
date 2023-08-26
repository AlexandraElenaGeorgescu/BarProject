using System.Collections.Generic;
using BarProject.Database_access;
using BarProject.Models;

namespace BarProject.Services
{
    public class BillService
    {
        private readonly DatabaseAccess _databaseAccess;

        public BillService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<Bill> GetBills()
        {
            return _databaseAccess.GetBills();
        }
        public void InsertBill(Bill bill)
        {
            _databaseAccess.InsertBill(bill);
        }

        public void UpdateBill(Bill bill)
        {
            _databaseAccess.UpdateBill(bill);
        }

        public void DeleteBill(int billId)
        {
            _databaseAccess.DeleteBill(billId);
        }


        // Add other methods as needed
    }
}