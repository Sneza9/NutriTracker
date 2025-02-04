using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Admin>> GetAdminById(int id)
    {
        var admin=await _context.Admins.FindAsync(id);
        if(admin==null)
            return NotFound();
        return admin;
    }

    [HttpPost]
    public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
    {
        admin.FirstName=Helper.CapitalizeFirstLetter(admin.FirstName);
        admin.LastName=Helper.CapitalizeFirstLetter(admin.LastName);
        
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAdminById), new{id=admin.Id}, admin);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);

        if (admin==null)
            return NotFound(); 
        
        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync(); 

        return NoContent();
    } 
}