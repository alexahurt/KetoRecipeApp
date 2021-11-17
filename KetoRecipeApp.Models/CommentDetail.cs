using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        public Guid UserId { get; set; }

        public int RecipeId { get; set; }

        public string RecipeTitle { get; set; }

        public double Rating { get; set; }
        public string Text { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
