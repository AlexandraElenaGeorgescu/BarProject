using BarProject.Database_access;
using BarProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Services
{
    public class EmployeeBillService
    {
        private readonly DatabaseAccess _databaseAccess;

        public EmployeeBillService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<EmployeeBill> GetEmployeeBills()
        {
            return _databaseAccess.GetEmployeeBills();
        }

        public void InsertEmployeeBill(EmployeeBill employeeBill)
        {
            _databaseAccess.InsertEmployeeBill(employeeBill);
        }

        public void UpdateEmployeeBill(EmployeeBill employeeBill)
        {
            _databaseAccess.UpdateEmployeeBill(employeeBill);
        }

        public void DeleteEmployeeBill(int employeeId, int billId)
        {
            _databaseAccess.DeleteEmployeeBill(employeeId, billId);
        }
    }
}

