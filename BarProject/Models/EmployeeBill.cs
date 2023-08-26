using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class EmployeeBill
    {
        public int EmployeeId { get; set; }
        public int BillId { get; set; }
        public Employee? Employee { get; set; }
        public Bill? Bill { get; set; }
    }
}
