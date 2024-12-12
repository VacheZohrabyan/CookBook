using Cookbook.Recipes.Ingredients;
using Cookbook.Recipes;

namespace Cookbook.App;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngreadientsFromUser();
}