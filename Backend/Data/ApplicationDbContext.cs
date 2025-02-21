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
        public DbSet<IngredientNutritionApi> IngredientNutritionsApi { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<IngredientNutrition> IngredientNutritions { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<MealIngredient> MealIngredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<FavoriteRecipe> FavoriteRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteRecipe>()
                .HasOne(fr => fr.Recipe)
                .WithMany(r => r.FavoriteRecipes)  // Ovim se izbegava duplikat
                .HasForeignKey(fr => fr.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FavoriteRecipe>()
                .HasOne(fr => fr.User)
                .WithMany(u => u.FavoriteRecipes)  // Ovim se izbegava duplikat
                .HasForeignKey(fr => fr.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }



    }
}