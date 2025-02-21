using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UpdateUnitDto
    {
        [Required]
        public double Amount { get; set; }
    }
}