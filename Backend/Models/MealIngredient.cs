using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class MealIngredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int MealId { get; set; }
        [Required]
        public int IngredientNutritionId { get; set; }
        [ForeignKey(nameof(MealId))]
        public Meal? Meal { get; set; } 
        [ForeignKey(nameof(IngredientNutritionId))]
        public IngredientNutrition? IngredientNutrition { get; set; } 
    }
}