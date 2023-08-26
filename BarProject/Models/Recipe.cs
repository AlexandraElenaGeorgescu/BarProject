using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarProject.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public int MenuItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal Quantity { get; set; }
        public MenuItem? MenuItem { get; set; }
        public Ingredient? Ingredient { get; set; }
    }
}
