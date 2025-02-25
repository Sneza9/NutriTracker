using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly MealService _mealService;

    public MealController(MealService mealService)
    {
        _mealService = mealService;
    }

    [HttpGet("{mealId}")]
    public async Task<ActionResult<Meal>> GetMealById(int mealId)
    {
        var meal = await _mealService.GetMeal(mealId);
        if (meal == null)
            return NotFound();
        return meal;
    }

    [HttpPost]
    public async Task<ActionResult<Meal>> CreateMeal(MealDto mealDto)
    {
        if (mealDto == null)
            return BadRequest("Invalid data.");
        Meal meal = new Meal();
        meal = await _mealService.Create(mealDto);

        return Ok(meal);
    }

    [HttpPut]
    public async Task<ActionResult<Meal>> UpdateMeal(int mealId, int? recipeId)
    {
        var meal = await _mealService.Update(mealId, recipeId);
        
        if (meal == null)
        {
            return NotFound();
        }
        return meal;
    }

    [HttpDelete("{mealId}")]
    public async Task<IActionResult> DeleteMeal(int mealId)
    {
        await _mealService.Remove(mealId);
        return NoContent();
    }
}