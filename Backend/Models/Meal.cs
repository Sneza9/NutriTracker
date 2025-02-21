using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Meal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public MealType MealType { get; set; } = MealType.Breakfast;
        public int TotalKCal { get; set; }
        public decimal TotalFat { get; set; } = decimal.Zero;
        public decimal TotalCarbohydrate { get; set; } = decimal.Zero;
        public decimal TotalProtein { get; set; } = decimal.Zero;
        public MealRating Rating { get; set; } = decimal.Zero;
        [DataType(DataType.Date)]
        public DateTime MealDate { get; set; }
        [Required]
        public int UserId { get; set; }
        public int? RecipeId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; } 
        [ForeignKey(nameof(RecipeId))]
        public Recipe? Recipe { get; set; } 
        [JsonIgnore]
        public List<MealIngredient> MealIngredients { get; set; }=new List<MealIngredient>();
    }
}