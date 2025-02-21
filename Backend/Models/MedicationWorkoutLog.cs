using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.Models
{
    public class MedicationWorkoutLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public bool Workout { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime MedicationWorkoutDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime MedicationTime { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int MedicationTimeId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; } 
        [ForeignKey(nameof(UserId))]
        public Medication? Medication { get; set; } 

    }
}