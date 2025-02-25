using System.ComponentModel.DataAnnotations;
using Backend.Models;

namespace Backend.DTOs
{
    public class MealDto
    {
        [Required]
        public MealType MealType { get; set; } = MealType.Breakfast;
        [Required]
        public int UserId { get; set; }
    }
}