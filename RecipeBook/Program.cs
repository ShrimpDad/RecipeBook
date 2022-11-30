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
            // Recipe followed is https://www.youtube.com/watch?v=P1gqm9CG8sw

            //Setup variables
            string response = "";

            //Setup recipes
            Recipe cookies = new Recipe("Levain-Style Cookies", 12, "cookies");

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
            Console.WriteLine($"\nThis recipe will make {cookies.Makes} {cookies.Unit}");

            //======================================================================================================================================= - segment to adjust ingredients by total output

            Console.WriteLine($"\nDo you want to adjust the recipe to make a certain amount of {cookies.Name}? (Y/N)");
            response = Console.ReadLine().ToLower();

            //Handle response from user
            if (response == "y")
            {
                //Ask user how many of the recipe they want to make and store the response
                Console.WriteLine($"\nPlease enter the number of {cookies.Name} you wish to make:");
                double requestedMakes = Convert.ToDouble(Console.ReadLine());

                //Figure out % difference of default recipie.Makes to requested recipe.Makes
                double requestedMakesAdjustment = requestedMakes / cookies.Makes;

                //Adjust recipe using requestedMakesAdjustment if the request doesn't bring recipe to or below zero
                if (requestedMakesAdjustment > 0)
                {
                    foreach (Ingredient ingredient in cookiesIngredients)
                    {
                        ingredient.Amount = ingredient.Amount * requestedMakesAdjustment;
                    }
                }
                //Print adjusted recipe
                if (requestedMakesAdjustment > 0)
                {
                    //Write to user
                    Console.WriteLine($"\nHere are the ingredients to make {cookies.Name} with adjusted quantities:\n");

                    //Iterate through list to say what they will need
                    foreach (Ingredient ingredient in cookiesIngredients)
                    {
                        ingredient.Amount = Math.Round(ingredient.Amount * requestedMakesAdjustment, 3);
                        Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} of {ingredient.Name}");
                    }

                    //Update Recipe.makes value
                    cookies.Makes = cookies.Makes * requestedMakesAdjustment;
                    Console.WriteLine($"\nThis will make {cookies.Makes} {cookies.Unit}");
                }
                else
                {
                    Console.WriteLine($"\nUnfortunately you cannot make {cookies.Makes * requestedMakesAdjustment} {cookies.Unit}");
                }
            }
            //======================================================================================================================================= - segment to adjust ingredients by available input
            else
            {
                //Ask user if they have enough of each ingredient and store the response
                Console.WriteLine("\nDo you want to adjust the recipe for the ingredients you have? (Y/N)");
                response = Console.ReadLine().ToLower();

                //Handle response from user
                if (response == "y")
                {
                    //Ask user how much of each ingredient they have and store it in the list
                    Console.WriteLine("\nPlease enter amounts of each ingredient");

                    foreach (Ingredient ingredient in cookiesIngredients)
                    {
                        //Takes a numeric double from user input for each ingredient
                        Console.WriteLine($"How many {ingredient.Unit} of {ingredient.Name} do you have?:");
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

                    //Print adjusted recipe
                    if (recipeAdjustment > 0)
                    {
                        //Write to user
                        Console.WriteLine($"\nHere is how to make {cookies.Name} with adjusted quantities:\n");

                        //Iterate through list to say what they will need
                        foreach (Ingredient ingredient in cookiesIngredients)
                        {
                            ingredient.Amount = Math.Round(ingredient.Amount * recipeAdjustment, 3);
                            Console.WriteLine($"{ingredient.Amount} {ingredient.Unit} of {ingredient.Name}");
                        }

                        //Update Recipe.makes value
                        cookies.Makes = cookies.Makes * recipeAdjustment;
                        Console.WriteLine($"\nThis will make {cookies.Makes} {cookies.Unit}");
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately you lack sufficent ingredient amounts to make this recipe");
                    }
                }
            }
            //======================================================================================================================================= - segment to print recipe steps

            //Setup steps
            Console.WriteLine($"\nTo make {cookies.Name} follow the below steps:");
            Console.WriteLine($"\nStep 1: \nDe-skin {cookiesIngredients.Find(x => x.Name == "Walnuts").Amount} {cookiesIngredients.Find(x => x.Name == "Walnuts").Unit} of {cookiesIngredients.Find(x => x.Name == "Walnuts").Name} by rubbing them together in a tea towel, and measure out {cookiesIngredients.Find(x => x.Name == "Milk Chocolate").Amount} {cookiesIngredients.Find(x => x.Name == "Milk Chocolate").Unit} of {cookiesIngredients.Find(x => x.Name == "Milk Chocolate").Name} chips");
            Console.WriteLine($"\nStep 2: \nIn a mixing bowl, lightly mix {cookiesIngredients.Find(x => x.Name == "Butter").Amount} {cookiesIngredients.Find(x => x.Name == "Butter").Unit} of cold, cubed {cookiesIngredients.Find(x => x.Name == "Butter").Name} with {cookiesIngredients.Find(x => x.Name == "Light Brown Sugar").Amount} {cookiesIngredients.Find(x => x.Name == "Light Brown Sugar").Unit} of {cookiesIngredients.Find(x => x.Name == "Light Brown Sugar").Name} and {cookiesIngredients.Find(x => x.Name == "Caster Sugar").Amount} {cookiesIngredients.Find(x => x.Name == "Caster Sugar").Unit} of {cookiesIngredients.Find(x => x.Name == "Caster Sugar").Name}");
            Console.WriteLine($"\nStep 3: \nAdd the {cookiesIngredients.Find(x => x.Name == "Walnuts").Amount} and {cookiesIngredients.Find(x => x.Name == "Milk Chocolate").Amount} chips to the mixing bowl and lightly mix until consistent");
            Console.WriteLine($"\nStep 4: \nAdd {cookiesIngredients.Find(x => x.Name == "Self-Raising Flour").Amount} {cookiesIngredients.Find(x => x.Name == "Self-Raising Flour").Unit} of {cookiesIngredients.Find(x => x.Name == "Self-Raising Flour").Name}, {cookiesIngredients.Find(x => x.Name == "Plain Flour").Amount} {cookiesIngredients.Find(x => x.Name == "Plain Flour").Unit} of {cookiesIngredients.Find(x => x.Name == "Plain Flour").Name}, {cookiesIngredients.Find(x => x.Name == "Salt").Amount} {cookiesIngredients.Find(x => x.Name == "Salt").Unit} of {cookiesIngredients.Find(x => x.Name == "Salt").Name}, {cookiesIngredients.Find(x => x.Name == "Bicarbonate Of Soda").Amount} {cookiesIngredients.Find(x => x.Name == "Bicarbonate Of Soda").Unit} of {cookiesIngredients.Find(x => x.Name == "Bicarbonate Of Soda").Name} and {cookiesIngredients.Find(x => x.Name == "Baking Powder").Amount} {cookiesIngredients.Find(x => x.Name == "Baking Powder").Unit} of {cookiesIngredients.Find(x => x.Name == "Baking Powder").Name} into the mixing bowl");
            Console.WriteLine($"\nStep 5: \nMix the ingredients until you reach a powdery breadcrumby texture");
            Console.WriteLine($"\nStep 6: \nAdd {cookiesIngredients.Find(x => x.Name == "Egg(s)").Amount} {cookiesIngredients.Find(x => x.Name == "Egg(s)").Unit} of lightly whisked {cookiesIngredients.Find(x => x.Name == "Egg(s)").Name} and mix until you form a cohesive and consistent dough");
            Console.WriteLine($"\nStep 7: \nPortion the dough into {cookies.Makes} equal spheres (~125 grams per each {cookies.Name}) and freeze these for 90 minutes");
            Console.WriteLine($"\nStep 8: \nPreheat an oven and tray to 180 degrees C (fan) and, once at temperature, place the frozen dough on the tray and bake for 17 minutes");
            Console.WriteLine($"\n{cookies.Name} can be stored for 3-4 days in tupperware in a cool dry place, you can keep any additional dough balls frozen to bake anytime");
            //Catch console exit with a ReadLine
            Console.ReadLine();
        }

    }

}
