using System.Text.Json.Serialization;
using System.Collections.Generic;

public class WeatherForecast
{
    [JsonPropertyName("daily")]
    public DailyForecast Daily { get; set; }
}

public class DailyForecast
{
    [JsonPropertyName("temperature_2m_max")]
    public List<double> MaxTemperatures { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double> MinTemperatures { get; set; }

    [JsonPropertyName("surface_pressure_max")]
    public List<double> MaxPressures { get; set; }

    [JsonPropertyName("surface_pressure_min")]
    public List<double> MinPressures { get; set; }

    [JsonPropertyName("time")]
    public List<string> Dates { get; set; }
}