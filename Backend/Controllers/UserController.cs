using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;

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
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        if (user.Gender == GenderType.Male)
            user.ImageUrl = "defaultMan.png";
        else
            user.ImageUrl = "defaultWoman.png";

        user.FirstName = Helper.CapitalizeAllFirstLetters(user.FirstName);
        user.LastName = Helper.CapitalizeAllFirstLetters(user.LastName);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        //201 
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        if (user == null)
        {
            //404 
            return NotFound();
        }

        //Provera po username da li postoji isti username 
        var userUsername = await _context.Users.FirstOrDefaultAsync(p => p.Username == updateUserDto.Username);
        if (userUsername != null)
        {
            if (userUsername.Username == user.Username)
                return BadRequest($"Username {userUsername.Username} is your username!");
            return BadRequest($"User with username {updateUserDto.Username} alrealdy exist, try another!");
        }
        if (updateUserDto.ImageUrl == "defaultMan.png" || updateUserDto.ImageUrl == "defaultWoman.png")
            user.ImageUrl = user.ImageUrl;
        else
            user.ImageUrl = updateUserDto.ImageUrl;

        user.Username = updateUserDto.Username;
        user.Therapy = updateUserDto.Therapy;
        user.Workout = updateUserDto.Workout;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            //404 
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}