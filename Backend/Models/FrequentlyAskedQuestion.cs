using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class FrequentlyAskedQuestion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string AskedQuestion { get; set; } = string.Empty;
        [MinLength(10)]
        public string AnsweredQuestion { get; set; } = string.Empty;
    }
}