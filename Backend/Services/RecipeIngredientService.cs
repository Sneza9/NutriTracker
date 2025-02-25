using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Services
{
    public class RecipeIngredientService
    {
        private readonly ApplicationDbContext _context;
        public RecipeIngredientService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<RecipeIngredient> Create(RecipeIngredientDto recipeIngDto)
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient();
            recipeIngredient.Amount = recipeIngDto.Amount;
            recipeIngredient.RecipeId = recipeIngDto.RecipeId;
            recipeIngredient.IngredientNutritionId = recipeIngDto.IngredientNutritionId;

            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == recipeIngDto.RecipeId);
            recipeIngredient.Recipe = recipe;

            var ingredient = _context.IngredientNutritions.FirstOrDefault(i => i.Id == recipeIngDto.IngredientNutritionId);
            recipeIngredient.IngredientNutrition = ingredient;

            await _context.RecipeIngredients.AddAsync(recipeIngredient);
            await _context.SaveChangesAsync();

            return recipeIngredient;
        }

        public async Task<IEnumerable<RecipeIngredient>> GetAllRecipeIngredients(int recipeId)
        {
            return await _context.RecipeIngredients
                        .Where(ri => ri.RecipeId == recipeId) 
                        .Include(ri => ri.IngredientNutrition)
                        .ToListAsync();
        }

        public async Task RemoveAllRecipeIngredients(int recipeId)
        {
            var ingredientsToDelete = await _context.RecipeIngredients
                                            .Where(r => r.RecipeId == recipeId)
                                            .ToListAsync();
            if (ingredientsToDelete.Any())
            {
                _context.RecipeIngredients.RemoveRange(ingredientsToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}