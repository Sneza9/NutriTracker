using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class RecipeIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // Sve se izrazava u gramima 
        [Required]
        public int Amount { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int IngredientNutritionId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public Recipe? Recipe { get; set; } 
        [ForeignKey(nameof(IngredientNutritionId))]
        public IngredientNutrition? IngredientNutrition { get; set; } 
    }
}