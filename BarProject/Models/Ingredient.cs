using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string? IngredientName { get; set; }
        public decimal Quantity { get; set; }
        public List<Recipe>? Recipes { get; set; }
        public List<Spending>? Spendings { get; set; }
    }
}
