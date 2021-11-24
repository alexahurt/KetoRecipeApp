using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetoRecipeApp.Data;

namespace KetoRecipeApp.Models
{
    public class RecipeEdit
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public _Category Category { get; set; }
        public _MealType MealType { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public int Protein { get; set; }

        public int TotalCarbs { get; set; }

        public int NetCarbs { get; set; }

        public int Calories { get; set; }
        public string Source { get; set; }
        public bool IsCleanKeto { get; set; }
    }
}
