using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly RecipeService _recipeService;

    public RecipeController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("{recipeId}")]
    public async Task<ActionResult<Recipe>> GetRecipeById(int recipeId)
    {
        var recipe = await _recipeService.GetRecipe(recipeId);
        if (recipe == null)
            return NotFound();
        return recipe;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe(RecipeDto recipeDto)
    {
        if (recipeDto == null)
            return BadRequest("Invalid data.");
        Recipe recipe = new Recipe();
        recipe = await _recipeService.Create(recipeDto);

        return Ok(recipe);
    }

    [HttpPut]
    public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId)
    {
        var recipe = await _recipeService.Update(recipeId);
        
        if (recipe == null)
        {
            return NotFound();
        }
        return recipe;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int recipeId)
    {
        await _recipeService.Remove(recipeId);
        return NoContent();
    }
}