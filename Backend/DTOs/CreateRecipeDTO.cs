using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;

namespace Backend.DTOs
{
    public class CreateRecipeDto
    {
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
    }
}
