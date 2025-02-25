using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;

public class MealService
{
    private readonly ApplicationDbContext _context;
    private readonly MealIngredientService _mealIngredientService;
    public MealService(ApplicationDbContext context, MealIngredientService mealIngredientService)
    {
        _context = context;
        _mealIngredientService = mealIngredientService;
    }

    public async Task<Meal> Create(MealDto mealDto)
    {
        Meal meal = new Meal();
        meal.MealType = mealDto.MealType;
        meal.UserId = mealDto.UserId;

        var user = await _context.Users.FindAsync(mealDto.UserId);
        meal.User = user;

        meal.TotalKCal = 0;
        meal.TotalCarbohydrate = 0;
        meal.TotalFat = 0;
        meal.TotalProtein = 0;
        meal.Rating = MealRating.Green;
        meal.MealDate = DateTime.Now;

        meal.RecipeId = null;
        meal.Recipe = null;

        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal?> GetMeal(int mealId)
    {
        return await _context.Meals
                         .Where(m => m.Id == mealId)
                         .Include(m => m.User)
                         .Include(m => m.Recipe)
                         .FirstOrDefaultAsync();
    }

    public async Task<Meal?> Update(int mealId, int? recipeId)
    {
        // Dodaju se opet svi, kako da filtriram samo postojece 
        var meal = await GetMeal(mealId);
        // Meal meal=new Meal();

        if (meal == null) return null;

        var listOfIngredients = await _mealIngredientService.GetAllMealIngredients(mealId);

        // var filteredIngredients = listOfIngredients
        // .Where(mealIng => !recipeIngredients.Any(recipeIng => recipeIng.IngredientId == mealIng.IngredientNutritionId))
        // .ToList();

        int totalKCal = 0;
        decimal totalCarbohydrate = 0, totalFat = 0, totalProtein = 0, totalGlycemicLoad = 0;

        foreach (var mealIngredient in listOfIngredients)
        {
            if (mealIngredient.IngredientNutrition != null)
            {
                totalKCal += (int)Math.Round((mealIngredient.IngredientNutrition.KCal * mealIngredient.Amount) / 100.0);
                totalCarbohydrate += (mealIngredient.IngredientNutrition.Carbohydrate * mealIngredient.Amount) / 100;
                totalGlycemicLoad += mealIngredient.IngredientNutrition.GI * totalCarbohydrate / 100;
                totalFat += (mealIngredient.IngredientNutrition.Fat * mealIngredient.Amount) / 100;
                totalProtein += (mealIngredient.IngredientNutrition.Protein * mealIngredient.Amount) / 100;
            }
        }
        if (recipeId.HasValue)
        {
            meal.Recipe = await _context.Recipes.FindAsync(recipeId);
            if (meal.Recipe != null)
            {
                totalKCal += meal.Recipe.TotalKCal / meal.Recipe.TotalServings;
                Console.WriteLine(totalKCal);
                totalCarbohydrate += meal.Recipe.TotalCarbohydrate / meal.Recipe.TotalServings;
                totalFat += meal.Recipe.TotalFat / meal.Recipe.TotalServings;
                totalProtein += meal.Recipe.TotalProtein / meal.Recipe.TotalServings;
                totalGlycemicLoad += meal.Recipe.GlycemicLoadPerServing;
            }
        }
        if (meal.Recipe != null)
        {
            totalKCal += meal.Recipe.TotalKCal / meal.Recipe.TotalServings;
            Console.WriteLine(totalKCal);
            totalCarbohydrate += meal.Recipe.TotalCarbohydrate / meal.Recipe.TotalServings;
            totalFat += meal.Recipe.TotalFat / meal.Recipe.TotalServings;
            totalProtein += meal.Recipe.TotalProtein / meal.Recipe.TotalServings;
            totalGlycemicLoad += meal.Recipe.GlycemicLoadPerServing;
        }

        if (totalGlycemicLoad < 10.9m)
        {
            meal.Rating = MealRating.Green;
        }
        else if (totalGlycemicLoad >= 11 && totalGlycemicLoad <= 19.9m)
        {
            meal.Rating = MealRating.Orange;
        }
        else
        {
            meal.Rating = MealRating.Red;
        }

        meal.TotalKCal = totalKCal;
        meal.TotalCarbohydrate = totalCarbohydrate;
        meal.TotalFat = totalFat;
        meal.TotalProtein = totalProtein;

        _context.Meals.Update(meal);
        await _context.SaveChangesAsync();

        return meal;
        // }
        // else
        // {
        //     meal.Recipe = await _context.Recipes.FindAsync(recipeId);
        //     {
        //         foreach (var mealIngredient in listOfIngredients)
        //         {
        //             if (mealIngredient.IngredientNutrition != null)
        //             {
        //                 totalKCal += (int)Math.Round((mealIngredient.IngredientNutrition.KCal * mealIngredient.Amount) / 100.0);
        //                 totalCarbohydrate += (mealIngredient.IngredientNutrition.Carbohydrate * mealIngredient.Amount) / 100;
        //                 totalGlycemicLoad += mealIngredient.IngredientNutrition.GI * totalCarbohydrate / 100;
        //                 totalFat += (mealIngredient.IngredientNutrition.Fat * mealIngredient.Amount) / 100;
        //                 totalProtein += (mealIngredient.IngredientNutrition.Protein * mealIngredient.Amount) / 100;
        //             }
        //         }

        //         //Uzima jednu porciju 
        //         totalKCal += meal.Recipe.TotalKCal / meal.Recipe.TotalServings;
        //         Console.WriteLine(totalKCal);
        //         totalCarbohydrate += meal.Recipe.TotalCarbohydrate / meal.Recipe.TotalServings;
        //         totalFat += meal.Recipe.TotalFat / meal.Recipe.TotalServings;
        //         totalProtein += meal.Recipe.TotalProtein / meal.Recipe.TotalServings;
        //         totalGlycemicLoad += meal.Recipe.GlycemicLoadPerServing;

        //         if (totalGlycemicLoad < 10.9m)
        //         {
        //             meal.Rating = MealRating.Green;
        //         }
        //         else if (totalGlycemicLoad >= 11 && totalGlycemicLoad <= 19.9m)
        //         {
        //             meal.Rating = MealRating.Orange;
        //         }
        //         else
        //         {
        //             meal.Rating = MealRating.Red;
        //         }

        //         meal.TotalKCal = totalKCal;
        //         meal.TotalCarbohydrate = totalCarbohydrate;
        //         meal.TotalFat = totalFat;
        //         meal.TotalProtein = totalProtein;

        //         _context.Meals.Update(meal);
        //         await _context.SaveChangesAsync();

        //         return meal;
        //     }
        // }
    }
    public async Task Remove(int mealId)
    {
        var meal = await _context.Meals.FindAsync(mealId);

        if (meal == null)
            return;
        else
        {
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }
    }
}