using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public string? ItemType { get; set; }
        public int Quantity { get; set; }
        public Bill? Bill { get; set; }
        public MenuItem? MenuItem { get; set; }
        public Drink? Drink { get; set; }
    }

}
