using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;

public class RecipeService
{
    private readonly ApplicationDbContext _context;
    private readonly RecipeIngredientService _recipeIngredientService;
    public RecipeService(ApplicationDbContext context, RecipeIngredientService recipeIngredientService)
    {
        _context = context;
        _recipeIngredientService = recipeIngredientService;
    }

    public async Task<Recipe> Create(RecipeDto recipeDto)
    {
        Recipe recipe = new Recipe();
        recipeDto.Title = Helper.CapitalizeFirstLetter(recipeDto.Title);
        recipeDto.Description = Helper.CapitalizeFirstLetterAfterPunctuation(recipeDto.Description);

        recipe.Title = recipeDto.Title;
        recipe.Description = recipeDto.Description;
        recipe.ImageUrl = recipeDto.ImageUrl;
        recipe.MealType = recipeDto.MealType;
        recipe.PrepTime = recipeDto.PrepTime;
        recipe.TotalServings = recipeDto.TotalServings;
        recipe.TotalKCal = 0;
        recipe.TotalCarbohydrate = 0;
        recipe.TotalProtein = 0;
        recipe.Rating = 0;
        recipe.RecipeUserId = recipeDto.RecipeUserId;

        var user = await _context.Users.FindAsync(recipeDto.RecipeUserId);
        recipe.User = user;

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return recipe;
    }
    public async Task<Recipe?> GetRecipe(int recipeId)
    {
        return await _context.Recipes
                    .Where(r => r.Id == recipeId)
                    .Include(r => r.User)
                    .FirstOrDefaultAsync();
    }

    public async Task<Recipe?> Update(int recipeId)
    {
        var recipe = await _context.Recipes.Where(r=>r.Id==recipeId).Include(r=>r.User).FirstOrDefaultAsync();
        if (recipe == null) return null;

        var listOfIngredients = await _recipeIngredientService.GetAllRecipeIngredients(recipeId);

        int totalKCal = 0;
        decimal totalCarbohydrate = 0, totalFat = 0, totalProtein = 0, totalGlycemicLoad = 0;

        foreach (var recipeIngredient in listOfIngredients)
        {
            if (recipeIngredient.IngredientNutrition != null)
            {
                totalKCal += (int)Math.Round((recipeIngredient.IngredientNutrition.KCal * recipeIngredient.Amount) / 100.0);
                totalCarbohydrate += (recipeIngredient.IngredientNutrition.Carbohydrate * recipeIngredient.Amount) / 100;
                totalGlycemicLoad += recipeIngredient.IngredientNutrition.GI * totalCarbohydrate / 100;
                totalFat += (recipeIngredient.IngredientNutrition.Fat * recipeIngredient.Amount) / 100;
                totalProtein += (recipeIngredient.IngredientNutrition.Protein * recipeIngredient.Amount) / 100;
            }
        }

        if (totalGlycemicLoad < 10.9m)
        {
            recipe.Rating = MealRating.Green;
        }
        else if (totalGlycemicLoad >= 11 && totalGlycemicLoad <= 19.9m)
        {
            recipe.Rating = MealRating.Orange;
        }
        else
        {
            recipe.Rating = MealRating.Red;
        }

        recipe.TotalKCal = totalKCal;
        recipe.TotalCarbohydrate = totalCarbohydrate;
        recipe.TotalFat = totalFat;
        recipe.TotalProtein = totalProtein;

        _context.Recipes.Update(recipe);
        await _context.SaveChangesAsync();

        return recipe;
    }

    public async Task Remove(int recipeId)
    {
        var recipe = await _context.Recipes.FindAsync(recipeId);

        if (recipe == null)
            return;
        else
        {
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }
    }
}
