using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string MedicationName { get; set; } = string.Empty;
    }
}