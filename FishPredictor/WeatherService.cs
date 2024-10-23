using System.Collections;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(List<DateTime> Dates, List<double> MaxTemperatures, List<double> MinTemperatures, List<double> AveragePressures)> GetWeatherForecastAsync()
    {
        var url = "https://api.open-meteo.com/v1/forecast?latitude=52&longitude=20&daily=temperature_2m_max,temperature_2m_min,surface_pressure_max,surface_pressure_min";

        // Отправка запроса на API
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Чтение и десериализация ответа JSON
        var content = await response.Content.ReadAsStringAsync();
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);

        // Создание списков для хранения дат (DateTime), температур и среднего давления
        List<DateTime> dates = new List<DateTime>();
        List<double> maxTemperatures = new List<double>();
        List<double> minTemperatures = new List<double>();
        List<double> averagePressures = new List<double>();

        for (int i = 0; i < 7; i++)
        {
            // Получение максимальной и минимальной температуры
            var maxTemp = weatherForecast?.Daily?.MaxTemperatures?[i] ?? double.NaN;
            var minTemp = weatherForecast?.Daily?.MinTemperatures?[i] ?? double.NaN;

            // Добавление температуры в списки
            maxTemperatures.Add(maxTemp);
            minTemperatures.Add(minTemp);

            // Расчет среднего давления
            var maxPressure = weatherForecast?.Daily?.MaxPressures?[i] ?? double.NaN;
            var minPressure = weatherForecast?.Daily?.MinPressures?[i] ?? double.NaN;
            var avgPressure = (maxPressure + minPressure) / 2;

            // Округление среднего давления до одного знака после запятой и добавление в список
            averagePressures.Add(Math.Round(avgPressure, 1));

            // Преобразование даты из строки в DateTime и добавление в список
            if (DateTime.TryParse(weatherForecast.Daily.Dates[i], out var parsedDate))
            {
                dates.Add(parsedDate);
            }
            else
            {
                throw new Exception($"Невозможно преобразовать строку даты '{weatherForecast.Daily.Dates[i]}' в DateTime.");
            }
        }

        return (dates, maxTemperatures, minTemperatures, averagePressures);
    }
}