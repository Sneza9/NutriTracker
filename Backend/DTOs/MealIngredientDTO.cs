using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class MealIngredientDto
    {
        
        [Required]
        public int Amount { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public int IngredientNutritionId { get; set; }
    }
}