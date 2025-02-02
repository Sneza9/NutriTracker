using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class FrequentlyAskedQuestion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MinLength(10)]
        public string AskedQuestion { get; set; } = string.Empty;
        [MinLength(10)]
        public string AnsweredQuestion { get; set; } = string.Empty;
    }
}