using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public List<Bill>? Bills { get; set; }
        public List<Spending>? Spendings { get; set; }
        public List<EmployeeBill>? EmployeesBills { get; set; }
    }
}
