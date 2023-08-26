using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Drink
    {
        public int DrinkId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
