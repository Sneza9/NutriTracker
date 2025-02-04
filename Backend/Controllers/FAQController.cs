using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using Backend.Services;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FAQController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FAQController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FrequentlyAskedQuestion>> GetFAQById(int id)
    {
        var faq = await _context.FAQs.FindAsync(id);

        if (faq == null)
            return NotFound();

        return faq;
    }

    [HttpPost]
    public async Task<ActionResult<FrequentlyAskedQuestion>> CreateFAQ(FrequentlyAskedQuestion faq)
    {
        faq.AskedQuestion=Helper.CapitalizeFirstLetterAfterPunctuation(faq.AskedQuestion);

        _context.FAQs.Add(faq);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetFAQById), new{id=faq.Id}, faq);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFAQ(int id, FrequentlyAskedQuestion f)
    {
        var faq = await _context.FAQs.FindAsync(id);

        if(faq==null)
            return NotFound();

        faq.AnsweredQuestion=f.AskedQuestion;
        faq.AnsweredQuestion=Helper.CapitalizeFirstLetterAfterPunctuation(faq.AnsweredQuestion);
        _context.FAQs.Update(faq);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFAQ(int id)
    {
        var faq = await _context.FAQs.FindAsync(id);

        if(faq==null)
            return NotFound();

        _context.FAQs.Remove(faq);
        await _context.SaveChangesAsync(); 

        return NoContent();         
    }
}