using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class NutritionProfileCreate
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public double Fat { get; set; }
        [Required]
        public double Protein { get; set; }
        [Required]
        public double TotalCarbs { get; set; }
        [Required]
        public double NetCarbs { get; set; }
        [Required]
        public double Calories { get; set; }
    }
}
