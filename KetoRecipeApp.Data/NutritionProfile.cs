using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetoRecipeApp.Data
{
    public class NutritionProfile
    {
        [Key]
        public int Id { get; set; }

        public double Fat { get; set; }

        public double Protein { get; set; }

        public double TotalCarbs { get; set; }

        public double NetCarbs { get; set; }

        public double Calories { get; set; }
    }
}
