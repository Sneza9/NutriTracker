using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { get; set; }=string.Empty;
        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { get; set; }=string.Empty;
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }=string.Empty;
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }=string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty;
    }
}