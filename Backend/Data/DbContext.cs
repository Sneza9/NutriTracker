using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<FrequentlyAskedQuestion> FAQs { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}