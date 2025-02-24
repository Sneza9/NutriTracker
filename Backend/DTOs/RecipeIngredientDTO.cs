using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs
{
    public class RecipeIngredientDto
    {
        [Required]
        public int Amount { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int IngredientNutritionId { get; set; }
    }
}