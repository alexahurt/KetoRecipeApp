using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentListItem
    {
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }
    }
}
