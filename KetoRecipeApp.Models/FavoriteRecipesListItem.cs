﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class FavoriteRecipesListItem
    {
        [Display(Name = "FavoriteRecipesID")]
        public int FavoriteRecipesId { get; set; }
        public Guid UserId { get; set; }

        [Display(Name = "Recipe ID")]
        public int RecipeId { get; set; }

        [Display(Name = "Recipe Title")]
        public string RecipeTitle { get; set; }
    }
}
