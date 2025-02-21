using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Data;
using Backend.Models;

public class RecipeService
{
    private readonly ApplicationDbContext _context;
    public RecipeService(ApplicationDbContext context)
    {
        _context = context;
    }


}
