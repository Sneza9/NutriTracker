using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return NotFound(); 

        //200 OK 
        return user;
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<User>> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        if (user == null)
            return NotFound();
        return user;
    }
    [HttpGet("username/{username}")]
    public async Task<ActionResult<User>> GetUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Username == username);
        if (user == null)
            //404
            return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        //201 
        return CreatedAtAction(nameof(GetUserById), new {id=user.Id}, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        if (user == null)
            //404
            return NotFound();
        var userUsername=await _context.Users.FirstOrDefaultAsync(p=>p.Username==updateUserDto.Username);
        if(userUsername != null)
            return BadRequest($"User with username {updateUserDto.Username} alrealdy exist, try another!"); 

        user.Username=updateUserDto.Username;
        user.Therapy=updateUserDto.Therapy;
        user.Workout=updateUserDto.Workout;
        user.ImageUrl=updateUserDto.ImageUrl;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user==null)
        {
            //404 
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }

}