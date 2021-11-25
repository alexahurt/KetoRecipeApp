using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetoRecipeApp.Data;

namespace KetoRecipeApp.Models
{
    public class RecipeDetail
    {
        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public _Category Category { get; set; }
        [Display(Name = "Meal Type")]
        public _MealType MealType { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public int Protein { get; set; }
        [Display(Name = "Total Carbs")]
        public int TotalCarbs { get; set; }
        [Display(Name = "Net Carbs")]

        public int NetCarbs { get; set; }

        public int Calories { get; set; }
        public string Source { get; set; }
        [Display(Name = "Is this dish clean keto?")]

        public bool IsCleanKeto { get; set; }

        public  IEnumerable<CommentListItem> Comments { get; set; }
    }
}
