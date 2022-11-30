using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    public class Recipe
    {
        public string Name { get; set; }
        public double Makes { get; set; }
        public string Unit { get; set; }

        public Recipe(string name, double makes, string unit)
        {
            Name = name;
            Makes = makes;
            Unit = unit;
                    }
    }
}
