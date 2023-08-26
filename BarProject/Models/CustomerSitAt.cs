using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class CustomerSitAt
    {
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public Customer? Customer { get; set; }
        public Table? Table { get; set; }
    }
}
