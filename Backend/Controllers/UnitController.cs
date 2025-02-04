using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UnitController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UnitController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Unit>> GetUnitById(int id)
    {
        var unit = await _context.Units.FindAsync(id);

        if (unit == null)
            return NotFound();

        return unit;
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> CreateUnit(Unit unit)
    {
        _context.Units.Add(unit);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUnitById), new { id = unit.Id }, unit);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUnit(int id, Unit unit)
    {
        var u = await _context.Units.FindAsync(id);

        if (u == null)
            return NotFound();

        u.Amount=unit.Amount;

        _context.Units.Update(u);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUnit(int id)
    {
        var unit = await _context.Units.FindAsync(id);

        if (unit == null)
            return NotFound();

        _context.Units.Remove(unit);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}