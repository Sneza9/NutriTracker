using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UpdateFaqDto
    {
        [MinLength(10)]
        public string AnsweredQuestion { get; set; } = string.Empty;
    }
}