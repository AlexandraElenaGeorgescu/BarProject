using System.Collections.Generic;
using BarProject.Database_access;
using BarProject.Models;

namespace BarProject.Services
{
    public class EmployeeService
    {
        private readonly DatabaseAccess _databaseAccess;

        public EmployeeService(DatabaseAccess databaseAccess)
        {
            _databaseAccess = databaseAccess;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _databaseAccess.GetEmployees();
        }
        public void InsertEmployee(Employee employee)
        {
            _databaseAccess.InsertEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _databaseAccess.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int employeeId)
        {
            _databaseAccess.DeleteEmployee(employeeId);
        }

        // Add other methods as needed
    }
}