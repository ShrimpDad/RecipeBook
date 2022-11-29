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
            Recipe cookies = new Recipe("Cookies",$"Eat them",12,"cookies");
            Recipe pancakes = new Recipe("Pancakes", "Eat them", 12, "pancakes");
            Dictionary<int, Recipe> recipeBook = new Dictionary<int, Recipe>();
            recipeBook.Add(1, cookies);
            recipeBook.Add(2, pancakes);

            Console.WriteLine(recipeBook[2].recipeName);
            Console.ReadLine();
        }
    }
}
