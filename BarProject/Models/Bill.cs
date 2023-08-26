using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer? Customer { get; set; }
        public Employee? Employee { get; set; }
        public List<Order>? Orders { get; set; }
        public List<EmployeeBill>? EmployeesBills { get; set; }
    }

}
