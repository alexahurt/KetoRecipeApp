using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class FavoriteRecipesCreate
    {
        [Required]
        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }
    }
}
