using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class RecipeListItem
    {
        [Display(Name = "Recipe ID")]

        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
    }
}
