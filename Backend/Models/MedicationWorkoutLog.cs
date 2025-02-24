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
        public int UserId { get; set; }
        public int MedicationId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; } 
        [ForeignKey(nameof(MedicationId))]
        public Medication? Medication { get; set; } 

    }
}