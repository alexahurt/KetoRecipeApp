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
        American =1,
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
        Breakfast =1,
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
        [Required]
        public Guid UserId { get; set; }
        public _Category Category { get; set; }
        [Required]
        public _MealType MealType { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public IEnumerable<NutritionProfile> NutritionProfile { get; set; }
        public string Source { get; set; }
        public bool IsCleanKeto { get; set; }

        public virtual List<Comment> Comments { get; set; }

    }

    public class NutritionProfile
    {
        public int NutritionProfileId { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double TotalCarbs { get; set; }

        public double NetCarbs { get; set; }

        public double Calories { get; set; }
    }
}
