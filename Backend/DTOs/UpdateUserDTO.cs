using Backend.Models;

namespace Backend.DTOs
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public bool Therapy { get; set; }
        public WorkoutType Workout { get; set; }

        public string ImageUrl { get; set; } = string.Empty;
    }
}