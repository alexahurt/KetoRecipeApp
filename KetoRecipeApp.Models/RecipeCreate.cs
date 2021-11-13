﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetoRecipeApp.Data;

namespace KetoRecipeApp.Models
{
    public class RecipeCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.") ]
        [MaxLength(50, ErrorMessage ="You have exceed the character limit of 50.")]
        public string Title { get; set; }
        public int Id { get; set; }
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
    }
}
