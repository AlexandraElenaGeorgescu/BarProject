using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Spending
    {
        public int SpendingId { get; set; }
        public int EmployeeId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public Employee? Employee { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
