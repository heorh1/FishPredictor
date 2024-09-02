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

    public async Task<(Hashtable Dates, List<double> MaxTemperatures, List<double> MinTemperatures, List<double> AveragePressures)> GetWeatherForecastAsync()
    {
        var url = "https://api.open-meteo.com/v1/forecast?latitude=52&longitude=20&daily=temperature_2m_max,temperature_2m_min,surface_pressure_max,surface_pressure_min";

        // Отправка запроса на API
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        // Чтение и десериализация ответа JSON
        var content = await response.Content.ReadAsStringAsync();
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(content);

        // Создание списков для хранения температур и среднего давления
        List<double> maxTemperatures = new List<double>();
        List<double> minTemperatures = new List<double>();
        List<double> averagePressures = new List<double>();

        // Создание Hashtable для хранения дат
        Hashtable dates = new Hashtable();

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

            // Добавление среднего давления в список
            averagePressures.Add(avgPressure);

            // Сохранение даты в Hashtable (ключи от 1 до 7)
            dates.Add(i + 1, weatherForecast?.Daily?.Dates?[i]);
        }

        return (dates, maxTemperatures, minTemperatures, averagePressures);
    }
}