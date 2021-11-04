using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Data
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }

        [Required]
        [Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        public string Text { get; set; }

    }
}

