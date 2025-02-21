using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RecipeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipeById(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        if (recipe == null)
            return NotFound();
        return recipe;
    }

    [HttpPost]
    public async Task<ActionResult<Recipe>> CreateRecipe(CreateRecipeDto recipeDto)
    {
        Recipe recipe = new Recipe();
        recipeDto.Title = Helper.CapitalizeFirstLetter(recipeDto.Title);
        recipeDto.Description=Helper.CapitalizeFirstLetterAfterPunctuation(recipeDto.Description);

        recipe.Title=recipeDto.Title;
        recipe.Description=recipeDto.Description;
        recipe.ImageUrl=recipeDto.ImageUrl;
        recipe.MealType=recipeDto.MealType;
        recipe.PrepTime=recipeDto.PrepTime;
        recipe.TotalServings=recipeDto.TotalServings;
        recipe.TotalKCal=recipeDto.TotalKCal;
        recipe.TotalCarbohydrate=recipeDto.TotalCarbohydrate;
        recipe.TotalProtein=recipeDto.TotalProtein;
        recipe.Rating=recipeDto.Rating;
        recipe.RecipeUserId=recipeDto.RecipeUserId;

        var user = await _context.Users.FindAsync(recipeDto.RecipeUserId);
        if(user==null)
            return NotFound();
        recipe.User=user;

        _context.Recipes.Add(recipe);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
    }

    //
    [HttpPut]
    public async Task<IActionResult> UpdateRecipe(int id, UpdateRecipeDto updateRecipe)
    {
        var rec = await _context.Recipes.FirstOrDefaultAsync(p => p.Id == id);
        if (rec == null)
            return NotFound();

        rec.Title=updateRecipe.Title;
        rec.Description=updateRecipe.Description;
        rec.MealType=updateRecipe.MealType;
        rec.PrepTime=updateRecipe.PrepTime;
        rec.ImageUrl=updateRecipe.ImageUrl;

        rec.Title = Helper.CapitalizeFirstLetter(rec.Title);
        rec.Description=Helper.CapitalizeFirstLetterAfterPunctuation(rec.Description);
        _context.Recipes.Update(rec);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        if (recipe == null)
            return NotFound();

        _context.Recipes.Remove(recipe);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}