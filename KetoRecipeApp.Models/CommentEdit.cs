using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentEdit
    {
        [Required]
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }

        [Required]
        [Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
