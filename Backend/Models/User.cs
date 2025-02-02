using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public GenderType Gender { get; set; } = GenderType.Male;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public bool Therapy { get; set; } = false;
        [Required]
        public WorkoutType Workout { get; set; } = WorkoutType.Without;
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public bool Premium { get; set; } = false;
    }

    public enum GenderType
    {
        Male,
        Female
    }
    public enum WorkoutType
    {
        Without,
        Low,
        Medium,
        High
    }
}
