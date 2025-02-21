using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class IngredientNutrition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int IngredientTypeId { get; set; }
        [Required]
        [MaxLength(255)]
        public string IngredientName { get; set; } = string.Empty;
        [Required]
        public int KCal { get; set; } 
        [Required]
        public decimal Fat { get; set; } = decimal.Zero;
        [Required]
        public decimal Carbohydrate { get; set; } = decimal.Zero;
        [Required]
        public decimal TotalSugar { get; set; } = decimal.Zero;
        [Required]
        public decimal Protein { get; set; } = decimal.Zero;
        [Required]
        public int GI { get; set; } 
        [ForeignKey(nameof(IngredientTypeId))]
        public IngredientType? IngredientType { get; set; } 
        [JsonIgnore]
        public List<MealIngredient> MealIngredients { get; set; } = new List<MealIngredient>();
        [JsonIgnore]
        public List<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    }
}