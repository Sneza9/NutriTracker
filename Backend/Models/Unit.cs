using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public UnitTypes UnitType { get; set; } = UnitTypes.Gram;
        [Required]
        public double Amount { get; set; }

    }

    public enum UnitTypes
    {
        Teaspoon,
        Tablespoon,
        Gram,
        Peace
    }

}