using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MedicationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Medication>> GetMedicationById(int id)
    {
        var medication = await _context.Medications.FindAsync(id);
        if (medication == null)
            return NotFound();
        return medication;
    }

    [HttpPost]
    public async Task<ActionResult<Medication>> CreateMedication(Medication medication)
    {
        medication.MedicationName = Helper.CapitalizeAllFirstLetters(medication.MedicationName);

        _context.Medications.Add(medication);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMedicationById), new { id = medication.Id }, medication);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMedication(int id, Medication medication)
    {
        var med = await _context.Medications.FirstOrDefaultAsync(p => p.Id == id);
        if (med == null)
            return NotFound();

        med.MedicationName = Helper.CapitalizeAllFirstLetters(medication.MedicationName);
        _context.Medications.Update(med);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedication(int id)
    {
        var medication = await _context.Medications.FindAsync(id);
        if (medication == null)
            return NotFound();

        _context.Medications.Remove(medication);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}