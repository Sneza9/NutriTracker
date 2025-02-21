using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientTypeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IngredientTypeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IngredientType>> GetIngredientTypeById(int id)
    {
        var ingredientType = await _context.IngredientTypes.FindAsync(id);
        if (ingredientType == null)
            return NotFound();
        return ingredientType;
    }

    [HttpPost]
    public async Task<ActionResult<IngredientType>> CreateIngredientType(IngredientType ingredientType)
    {
        ingredientType.IngredientTypeName = Helper.CapitalizeFirstLetter(ingredientType.IngredientTypeName);

        _context.IngredientTypes.Add(ingredientType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIngredientTypeById), new { id = ingredientType.Id }, ingredientType);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIngredientType(int id, IngredientType ingredientType)
    {
        var ingT = await _context.IngredientTypes.FindAsync(id);
        if (ingT == null)
            return NotFound();

        ingT.IngredientTypeName = Helper.CapitalizeFirstLetter(ingredientType.IngredientTypeName);
        _context.IngredientTypes.Update(ingT);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredientType(int id)
    {
        var ingType = await _context.IngredientTypes.FindAsync(id);
        if (ingType == null)
            return NotFound();

        _context.IngredientTypes.Remove(ingType);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}