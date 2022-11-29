using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    public class Ingredient
    {
        public string ingredientName { get; set; }
        public double ingredientAmount { get; set; }
        public string ingredientAmountUnit { get; set; }

        public Ingredient (string ingredientNameInput, double ingredientAmountInput, string ingredientAmountUnitInput)
        {
            ingredientName = ingredientNameInput;
            ingredientAmount = ingredientAmountInput;
            ingredientAmountUnit = ingredientAmountUnitInput;
        }
    }
}
