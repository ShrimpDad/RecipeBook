using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            //Setup recipes
            Recipe cookies = new Recipe("NYC Cookies", 12, "cookies");

            //Setup an ingredients list
            List<Ingredient> cookiesIngredients = new List<Ingredient>();


            //Add ingredients to a list to iterate through
            cookiesIngredients.Add(new Ingredient { Name = "Walnuts", Amount = 100, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Milk Chocolate", Amount = 400, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Butter", Amount = 230, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Caster Sugar", Amount = 160, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Light Brown Sugar", Amount = 160, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Self-Raising Flour", Amount = 200, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Plain Flour", Amount = 300, Unit = "grams" });
            cookiesIngredients.Add(new Ingredient { Name = "Salt", Amount = 0.25, Unit = "teaspoons" });
            cookiesIngredients.Add(new Ingredient { Name = "Bicarbonate Of Soda", Amount = 0.25, Unit = "teaspoons" });
            cookiesIngredients.Add(new Ingredient { Name = "Baking Powder", Amount = 2, Unit = "teaspoons" });
            cookiesIngredients.Add(new Ingredient { Name = "Egg(s)", Amount = 2, Unit = "egg(s)" });

            //Write to user
            Console.WriteLine($"Here is how to make {cookies.Name}:\n");

            //Iterate through list to say what they will need
            foreach (Ingredient ingredient in cookiesIngredients)
            {
                Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} of {ingredient.Name}");
            }

            //Write to user
            Console.WriteLine($"\nThis will make {cookies.Makes} {cookies.Unit}");

            //Ask user if they have enough of each ingredient and store the response
            Console.WriteLine("Do you have suffcient amounts of each ingredient? (Y/N)");
            string response = Console.ReadLine().ToLower();

            //Handle response from user
            if (response == "n")
            {
                //Ask user how much of each ingredient they have and store it in a new list
                Console.WriteLine("Please enter amounts of each ingredient:");

                foreach (Ingredient ingredient in cookiesIngredients)
                {
                    //Takes a numeric double from user input for each ingredient
                    Console.WriteLine($"How many {ingredient.Unit} of {ingredient.Name} do you have?");
                    ingredient.Held = Convert.ToDouble(Console.ReadLine());

                    //Figure out % difference deviation of the lowest common denominator from the standard recipe
                    ingredient.PercentHeld = ingredient.Held / ingredient.Amount;
                }

                //Then run through each ingredient and update the lowest common denominator
                double recipeAdjustment = double.MaxValue;
                foreach (Ingredient ingredient in cookiesIngredients)
                {
                    //Decides if the current ingredients percent held is less than the current lowest adjustment, and amends the adujstment if it is
                    if (ingredient.PercentHeld < recipeAdjustment)
                    {
                        recipeAdjustment = ingredient.PercentHeld;
                    }
                }

                if (recipeAdjustment >= 0.001)
                {
                    //Write to user
                    Console.WriteLine($"\nHere is how to make {cookies.Name} with adjusted quantities:\n");

                    //Iterate through list to say what they will need
                    foreach (Ingredient ingredient in cookiesIngredients)
                    {
                        Console.WriteLine($"{ingredient.Amount * recipeAdjustment} {ingredient.Unit} of {ingredient.Name}");
                    }

                    Console.WriteLine($"\nThis will make {cookies.Makes * recipeAdjustment} {cookies.Unit}");
                }
                else
                {
                    Console.WriteLine("Unfortunately you lack sufficent ingredient amounts to make this recipe");
                }
                
            }

            //Setup steps
            

            //Catch console exit with a ReadLine
            Console.ReadLine();
        }

    }

}
