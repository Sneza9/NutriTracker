using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientNutritionApiController : ControllerBase
{
    private readonly UsdaApiService _usdaApiService;
    private readonly ApplicationDbContext _context;

    public IngredientNutritionApiController(UsdaApiService usdaApiService, ApplicationDbContext context)
    {
        _usdaApiService = usdaApiService;
        _context = context;
    }

    [HttpGet("addingredient")]
    public async Task<IActionResult> AddIngredient(string query)
    {
        var ingredient = await _usdaApiService.GetFoodDataAsync(query);

        if (ingredient == null)
        {
            return NotFound("Ingredient not found.");
        }
        
        _context.IngredientNutritionsApi.Add(ingredient);
        await _context.SaveChangesAsync();

        return Ok(ingredient);
    }
}

