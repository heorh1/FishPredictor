

namespace FishPredictor.DB
{
    public class Fish
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double PressureMin { get; set; }
        public double PressureMax { get; set; }
    }
}
