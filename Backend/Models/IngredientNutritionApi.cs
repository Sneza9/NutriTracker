using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    //Zavisice od apija sa kog preuzimam namirnice 
    public class IngredientNutritionApi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int FdcId { get; set; } //Unique 
        [Required]
        [MaxLength(255)]
        public string IngredientName { get; set; } = string.Empty;
        [Required]
        public decimal KCal { get; set; } = decimal.Zero;
        [Required]
        public decimal Fat { get; set; } = decimal.Zero;
        [Required]
        public decimal Carbohydrate { get; set; } = decimal.Zero;
        [Required]
        public decimal Protein { get; set; } = decimal.Zero;
    }
}