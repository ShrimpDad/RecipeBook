using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    public class Recipe
    {
        public string recipeName { get; set; }
        //public List<Ingredient> = new List<Ingredient>();
        public string recipeSteps { get; set; }
        public int recipeMakes { get; set; }
        public string recipeMakeUnits { get; set; }

        public Recipe (string recipeNameInput, string recipeStepsInput, int recipeMakesInput, string recipeMakeUnitsInput)
        {
            recipeName = recipeNameInput;
            recipeSteps = recipeStepsInput;
            recipeMakes = recipeMakesInput;
            recipeMakeUnits = recipeMakeUnitsInput;
        }
    }
}
