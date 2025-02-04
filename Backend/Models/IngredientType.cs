using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class IngredientType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string IngredientTypeName { get; set; } = string.Empty;
        [JsonIgnore]
        public List<IngredientNutrition> ingredientNutritions { get; set; } = new List<IngredientNutrition>();
    }


}