using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public MealType MealType { get; set; } = MealType.Breakfast;
        [Required]
        public int PrepTime { get; set; }
        [Required]
        public int TotalServings { get; set; }
        public int TotalKCal { get; set; }
        public decimal TotalFat { get; set; } = decimal.Zero;
        public decimal TotalCarbohydrate { get; set; } = decimal.Zero;
        public decimal TotalProtein { get; set; } = decimal.Zero;
        public MealRating Rating { get; set; } = decimal.Zero;
        [Required]
        public int RecipeUserId { get; set; }
        [ForeignKey(nameof(RecipeUserId))]
        public User? User { get; set; }
        [JsonIgnore]
        public List<Meal> Meals { get; set; } = new List<Meal>();
        [JsonIgnore]
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        [JsonIgnore]
        public List<FavoriteRecipe> FavoriteRecipes { get; set; } = new List<FavoriteRecipe>();
    }

    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack
    }

    public enum MealRating
    {
        Green,
        Orange,
        Red
    }
}
