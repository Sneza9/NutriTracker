using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class MedicationWorkoutLogDto
    {
        [Required]
        public bool Workout { get; set; }
        [Required]
        public int UserId { get; set; }
        public int MedicationId { get; set; } 
    }
}