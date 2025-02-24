using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;

public class MedicationWorkoutLogService
{
    private readonly ApplicationDbContext _context;
    public MedicationWorkoutLogService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<MedicationWorkoutLog> Create(MedicationWorkoutLogDto medwlogDto)
    {
        MedicationWorkoutLog medwlog = new MedicationWorkoutLog();
        medwlog.Workout = medwlogDto.Workout;
        medwlog.MedicationWorkoutDate = DateTime.Now;
        medwlog.UserId = medwlogDto.UserId;
        medwlog.MedicationId = medwlogDto.MedicationId;

        var user = _context.Users.FirstOrDefault(u => u.Id == medwlogDto.UserId);
        medwlog.User = user;

        if (user != null && user.Therapy == true)
        {
            var medication = _context.Medications.FirstOrDefault(m => m.Id == medwlogDto.MedicationId);
            medwlog.Medication = medication;
        }
        else
        {
            medwlog.Medication = null;
        }

        await _context.MedicationWorkoutLogs.AddAsync(medwlog);
        await _context.SaveChangesAsync();

        return medwlog;
    }
    public async Task<IEnumerable<MedicationWorkoutLog>> GetAllLogsByDateTimeNow(int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (user != null && user.Therapy == true)
        {
            return await _context.MedicationWorkoutLogs
                        .Where(m => m.UserId == userId)
                        .Where(d => d.MedicationWorkoutDate == DateTime.Now)
                        .Include(m => m.User)
                        .Include(m => m.Medication)
                        .ToListAsync();
        }
        else
        {
            return await _context.MedicationWorkoutLogs
                        .Where(m => m.UserId == userId)
                        .Where(d => d.MedicationWorkoutDate == DateTime.Now)
                        .Include(m => m.User)
                        .ToListAsync();
        }
    }

    public async Task<IEnumerable<MedicationWorkoutLog>> GetAllLogsByUserId(int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (user != null && user.Therapy)
        {
            return await _context.MedicationWorkoutLogs
                        .Where(m => m.UserId == userId)
                        .Include(m => m.User)
                        .Include(m => m.Medication)
                        .ToListAsync();
        }
        else
        {
            return await _context.MedicationWorkoutLogs
                        .Where(m => m.UserId == userId)
                        .Include(m => m.User)
                        .ToListAsync();
        }
    } 
    public async Task<IEnumerable<MedicationWorkoutLog>> GetMedicationWorkoutLogByUserId(int userId)
    {
        return await _context.MedicationWorkoutLogs
            .Where(m => m.UserId == userId)
            .Include(m => m.User)
            .Include(m => m.Medication)
            .ToListAsync();
    }


    public async Task RemoveAll(int userId)
    {
        var logsToDelete = await _context.MedicationWorkoutLogs
                                         .Where(log => log.UserId == userId)
                                         .ToListAsync(); // Učitaj samo relevantne podatke

        if (logsToDelete.Any())
        {
            _context.MedicationWorkoutLogs.RemoveRange(logsToDelete);
            await _context.SaveChangesAsync();
        }
    }

}
