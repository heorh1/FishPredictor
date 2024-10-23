namespace FishPredictor
{
    public class WeatherData
    {
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double AveragePressure { get; set; }

        public WeatherData(double minTemp, double maxTemp, double avgPressure)
        {
            MinTemperature = minTemp;
            MaxTemperature = maxTemp;
            AveragePressure = avgPressure;
        }
    }
}
