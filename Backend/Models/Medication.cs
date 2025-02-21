using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Backend.Models
{
    public class Medication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string MedicationName { get; set; } = string.Empty;
        [JsonIgnore]
        public List<MedicationWorkoutLog> MedicationWorkoutLog { get; set; } = new List<MedicationWorkoutLog>();
    }
}