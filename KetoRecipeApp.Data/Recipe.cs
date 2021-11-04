using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Data
{

    public enum _Category
    {
        American,
        Italian,
        Asian,
        African,
        Mediterranean,
        Mexican,
        Spanish,
        French,
        Greek,
        MiddleEastern,
        Misc
    }

    public enum _MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack,
        Dessert
    }
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public _Category Category { get; set; }
        [Required]
        public _MealType MealType { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public virtual NutritionProfile NutritionProfile { get; set; }
        public string Source { get; set; }
        public bool IsCleanKeto { get; set; }

    }
}
