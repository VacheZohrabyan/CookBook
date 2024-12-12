using Cookbook.App;
using Cookbook.DataAccess;
using Cookbook.FileAccess;
using Cookbook.Recipes;
using Cookbook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
        new StringsJsonRepository() : 
        new StringsTextualRepository();
const string fileName = "recipes";
var fileMetaData = new FileMetaData(fileName, Format);

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConnsoleUserInteraction(
        ingredientsRegister));
    
cookiesRecipesApp.Run(fileMetaData.ToPath());    