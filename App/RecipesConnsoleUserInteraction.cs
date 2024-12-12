using Cookbook.Recipes.Ingredients;
using Cookbook.Recipes;
using System.Linq;

namespace Cookbook.App;

public class RecipesConnsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConnsoleUserInteraction(
        IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            int counter = 0;
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{counter + 1}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
                          "Available ingredients are: ");
        foreach (var ingredient in _ingredientsRegister.All)
        { 
             Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngreadientsFromUser()
    {
        bool shellStop = false;
        var ingredients = new List<Ingredient>();

        while (!shellStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                              "or type anything else if finished.");

            var userinput = Console.ReadLine();

            if (int.TryParse(userinput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shellStop = true;
            }
        }

        return ingredients;
    }
}