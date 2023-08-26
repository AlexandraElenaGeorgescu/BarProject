using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public List<Table>? Tables { get; set; }
        public List<Bill>? Bills { get; set; }
    }

}
