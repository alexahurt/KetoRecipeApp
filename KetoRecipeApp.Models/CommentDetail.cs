using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentDetail
    {
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }

        public Guid UserId { get; set; }

        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }

        public double Rating { get; set; }
        public string Text { get; set; }

        [Display(Name = "Comment Created Date")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
