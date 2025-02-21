namespace Backend.DTOs
{
    public class FoodItemDto
    {
        public int FdcId { get; set; }
        public string? Description { get; set; }
        public List<FoodNutrientDto>? FoodNutrients { get; set; }
    }
}
