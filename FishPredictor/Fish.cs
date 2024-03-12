using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishPredictor
{
    public class Fish
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The name of the fish is required.")]
        [Column("FishName")]  
        public required string Name { get; set; }

        [Display(Name = "Temperature Min")]
        public double TemperatureMin { get; set; }

        [Display(Name = "Temperature Max")]
        public double TemperatureMax { get; set; }

        [Display(Name = "Pressure Min")]
        public double PressureMin { get; set; }

        [Display(Name = "Pressure Max")]
        public double PressureMax { get; set; }
    }
}
