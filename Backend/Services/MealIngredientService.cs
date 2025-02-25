using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Services
{
    public class MealIngredientService
    {
        private readonly ApplicationDbContext _context;
        public MealIngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MealIngredient> Create(MealIngredientDto mealIngredientDto)
        {
            MealIngredient mealIngredient = new MealIngredient();
            mealIngredient.Amount=mealIngredientDto.Amount;
            mealIngredient.MealId = mealIngredientDto.MealId;
            mealIngredient.IngredientNutritionId = mealIngredientDto.IngredientNutritionId;

            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealIngredientDto.MealId);
            mealIngredient.Meal = meal;

            var ingredient = _context.IngredientNutritions.FirstOrDefault(i => i.Id == mealIngredientDto.IngredientNutritionId);
            mealIngredient.IngredientNutrition = ingredient;

            await _context.MealIngredients.AddAsync(mealIngredient);
            await _context.SaveChangesAsync();

            return mealIngredient;
        }

        public async Task<IEnumerable<MealIngredient>> GetAllMealIngredients(int mealId)
        {
            return await _context.MealIngredients
                        .Where(m => m.MealId == mealId)
                        .Include(m => m.IngredientNutrition)
                        .ToListAsync();
        }

        public async Task RemoveAllMealIngredients(int mealId)
        {
            var ingredientsToDelete = await _context.MealIngredients
                                            .Where(m => m.MealId == mealId)
                                            .ToListAsync();
            if (ingredientsToDelete.Any())
            {
                _context.MealIngredients.RemoveRange(ingredientsToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}