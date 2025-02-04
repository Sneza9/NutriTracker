using Backend.Models;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientNutritionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IngredientNutritionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientNutrition>> GetIngredientNutritionById(int id)
    {
        var ingredientNutritionApi = await _context.IngredientNutritions.FindAsync(id);

        if (ingredientNutritionApi == null)
            return NotFound();

        return ingredientNutritionApi;
    }

    [HttpPost]
    public async Task<ActionResult<IngredientNutrition>> CreateIngredientNutrition(IngredientNutrition ingredientN)
    {
        ingredientN.IngredientName = Helper.CapitalizeFirstLetter(ingredientN.IngredientName);
        _context.IngredientNutritions.Add(ingredientN);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIngredientNutritionById), new { id = ingredientN.Id }, ingredientN);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIngredientNutrition(int id, IngredientNutrition ingredientN)
    {
        var ingN = await _context.IngredientNutritions.FindAsync(id);

        if (ingN == null)
            return NotFound();

        ingN.KCal = ingredientN.KCal;
        ingN.Carbohydrate = ingredientN.Carbohydrate;
        ingN.TotalSugar = ingredientN.TotalSugar;
        ingN.Fat = ingredientN.Fat;
        ingN.Protein = ingredientN.Protein;

        _context.IngredientNutritions.Update(ingN);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredientNutrition(int id)
    {
        var ingN = await _context.IngredientNutritions.FindAsync(id);

        if (ingN == null)
            return NotFound();

        _context.IngredientNutritions.Remove(ingN); 
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}