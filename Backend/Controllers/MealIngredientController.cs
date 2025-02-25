using Microsoft.AspNetCore.Mvc;
using Backend.DTOs;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealIngredientController : ControllerBase
    {
        private readonly MealIngredientService _mealIngService;
        public MealIngredientController(MealIngredientService mealIngService)
        {
            _mealIngService = mealIngService;
        }
        [HttpGet("{mealId}")]
        public async Task<IActionResult> GetMealIngredients(int mealId)
        {
            var ingredients = await _mealIngService.GetAllMealIngredients(mealId);

            if (ingredients == null)
                return NotFound("No ingredients found for this meal.");

            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MealIngredientDto mealIngredientDto)
        {
            if(mealIngredientDto==null)
                return BadRequest("Invalid data");
            
            var mealIngredient= await _mealIngService.Create(mealIngredientDto);

            return CreatedAtAction(nameof(GetMealIngredients), new {mealId=mealIngredient.Id}, mealIngredient);
        }

        [HttpDelete("{mealId}")]
        public async Task<IActionResult> RemoveAll(int mealId)
        {
            await _mealIngService.RemoveAllMealIngredients(mealId);
            return NoContent();
        }
    }
}