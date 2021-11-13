using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentCreate
    {
        [Required]
        public int RecipeId { get; set; }

        [Required]
        [Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
