using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public UnitTypes UnitType { get; set; } = UnitTypes.Gram;
        [Required]
        public double Amount { get; set; }

    }

    public enum UnitTypes
    {
        Teaspoon = 5,
        Tablespoon = 15,
        Gram = 1,
        Peace = 1
    }

}