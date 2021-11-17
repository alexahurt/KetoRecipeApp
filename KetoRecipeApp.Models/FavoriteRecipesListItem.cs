using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class FavoriteRecipesListItem
    {
        public int FavoriteRecipesId { get; set; }
        public Guid UserId { get; set; }
        public int RecipeId { get; set; }
        public string Title { get; set; }
    }
}
