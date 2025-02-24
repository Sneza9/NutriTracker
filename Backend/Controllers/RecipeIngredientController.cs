using Microsoft.AspNetCore.Mvc;
using Backend.DTOs;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeIngredientController : ControllerBase
    {
        private readonly RecipeIngredientService _recipeIngService;
        public RecipeIngredientController(RecipeIngredientService recipeIngService)
        {
            _recipeIngService = recipeIngService;
        }
        [HttpGet("{recipeId}")]
        public async Task<IActionResult> GetRecipeIngredients(int recipeId)
        {
            var ingredients = await _recipeIngService.GetAllRecipeIngredients(recipeId);

            if (ingredients == null)
                return NotFound("No ingredients found for this recipe.");

            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecipeIngredientDto recipeIngredientDto)
        {
            if(recipeIngredientDto==null)
                return BadRequest("Invalid data");

            var recipeIngredient= await _recipeIngService.Create(recipeIngredientDto);

            return CreatedAtAction(nameof(GetRecipeIngredients), new {recipeId=recipeIngredient.Id}, recipeIngredient);
        }

        [HttpDelete("{recipeId}")]
        public async Task<IActionResult> RemoveAll(int recipeId)
        {
            await _recipeIngService.RemoveAllRecipeIngredients(recipeId);
            return NoContent();
        }
    }
}