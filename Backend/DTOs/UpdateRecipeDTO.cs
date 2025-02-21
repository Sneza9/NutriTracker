using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.DTOs
{
    public class UpdateRecipeDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;        
        public string ImageUrl { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public MealType MealType { get; set; } = MealType.Breakfast;
        public int PrepTime { get; set; }
        
    }
}