using System.ComponentModel.DataAnnotations; 

namespace Backend.Models
{
    //Zavisice od apija sa kog preuzimam namirnice 
    public class Ingredient 
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [MinLength(2)]
        public string IngredientName { get; set; } = string.Empty;
        [Required]
        public int KCal { get; set; }
        [Required]
        public int Fat { get; set; }
        [Required]
        public int Carbohydrate { get; set; } 
        [Required]
        public int Protein { get; set; } 
    }
}