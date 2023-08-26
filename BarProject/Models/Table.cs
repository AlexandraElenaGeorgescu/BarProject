using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<CustomerSitAt>? CustomersSitAt { get; set; }
    }
}
