using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    public class Ingredient 
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public double Held { get; set; }
        public double PercentHeld { get; set; }
    }
}
