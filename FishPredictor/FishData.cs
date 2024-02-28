namespace FishPredictor
{
    public class FishData
    {
        public static List<Fish> GetFishData()
        {
            return new List<Fish>
        {
            new Fish { FishID = 1, Name = "Bream", TemperatureMin = -25, TemperatureMax = 30, PressureMin = 700, PressureMax = 800 },
            new Fish { FishID = 2, Name = "Carp", TemperatureMin = 0, TemperatureMax = 30, PressureMin = 750, PressureMax = 800 },
            new Fish { FishID = 3, Name = "Roach", TemperatureMin = -20, TemperatureMax = 30, PressureMin = 720, PressureMax = 800 },
            new Fish { FishID = 4, Name = "Perch", TemperatureMin = -20, TemperatureMax = 30, PressureMin = 760, PressureMax = 800 },
            new Fish { FishID = 5, Name = "Catfish", TemperatureMin = 15, TemperatureMax = 30, PressureMin = 750, PressureMax = 780 }
        };
        }
    }
}
