using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public double Rating { get; set; }
        public string Text { get; set; }
    }
}
