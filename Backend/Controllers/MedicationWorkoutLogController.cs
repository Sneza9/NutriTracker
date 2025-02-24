using Microsoft.AspNetCore.Mvc;
using Backend.DTOs;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicationWorkoutLogController : ControllerBase
{
    private readonly MedicationWorkoutLogService _medwlogService;
    public MedicationWorkoutLogController(MedicationWorkoutLogService medwlogService)
    {
        _medwlogService = medwlogService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult> GetUserLogs(int userId)
    {
        var logs = await _medwlogService.GetAllLogsByUserId(userId);

        if (logs == null)
            return NotFound("No logs found for this user.");

        return Ok(logs);
    }

    [HttpPost]
    public async Task<ActionResult> Create(MedicationWorkoutLogDto medwlogDto)
    {
        if (medwlogDto == null)
            return BadRequest("Invalid data.");

        var createdLog = await _medwlogService.Create(medwlogDto);

        return CreatedAtAction(nameof(GetUserLogs), new { userId = createdLog.UserId }, createdLog);
    }

    [HttpDelete("{userId}")]
    public async Task<ActionResult> RemoveAll(int userId)
    {
        await _medwlogService.RemoveAll(userId);
        return NoContent(); // 204 No Content, jer DELETE obično ne vraća telo odgovora
    }

}