using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishPredictor.DB;
using System.Collections;

namespace FishPredictor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishesController : ControllerBase
    {
        private readonly FishContext _context;
        private readonly WeatherService _weatherService;

        public FishesController(FishContext context, WeatherService weatherService)
        {
            _context = context;
            _weatherService = weatherService;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAllFishes()
        {
            var fishes = await _context.Fishes.ToListAsync();
            return Ok(fishes);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFishDetails(int id)
        {
            var fish = await _context.Fishes.FindAsync(id);

            if (fish == null)
            {
                return NotFound();
            }
            return Ok(fish);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> CreateFish([FromBody] Fish fish)
        {
            _context.Fishes.Add(fish);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFishDetails), new { id = fish.Id }, fish);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFish(int id, [FromBody] Fish fish)
        {
            if (id != fish.Id)
            {
                return BadRequest();
            }

            _context.Entry(fish).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFish(int id)
        {
            var fish = await _context.Fishes.FindAsync(id);

            if (fish == null)
            {
                return NotFound();
            }

            _context.Fishes.Remove(fish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // NEW METHOD FOR WEATHER DATA
        [HttpGet("weather")]
        public async Task<IActionResult> GetWeather()
        {
            var (dates, maxTemperatures, minTemperatures, averagePressures) = await _weatherService.GetWeatherForecastAsync();

            return Ok(new
            {
                Dates = dates,
                MaxTemperatures = maxTemperatures,
                MinTemperatures = minTemperatures,
                AveragePressures = averagePressures
            });
        }


        // RETURN HashTable<weatherData.Dates[i], weatherInfo>
        [HttpGet("weather-hashtable")]
        public async Task<IActionResult> GetWeatherHashTable()
        {
            // Receiving weather data through a weather service
            var weatherData = await _weatherService.GetWeatherForecastAsync();

            // Creating a Hashtable to store data
            var weatherHashTable = new Hashtable();

            // Filling the Hashtable: key - date, value - WeatherData object
            for (int i = 0; i < weatherData.Dates.Count; i++)
            {
                // Create a WeatherData object for each date
                var weatherInfo = new WeatherData(
                    weatherData.MinTemperatures[i],
                    weatherData.MaxTemperatures[i],
                    weatherData.AveragePressures[i]
                );

                //Add date as key and weather data as value to Hashtable
                weatherHashTable.Add(weatherData.Dates[i], weatherInfo);
            }

            // Returning the result in JSON format
            return Ok(weatherHashTable);
        }


        [HttpGet("active-fish-hashtable")]
        public async Task<IActionResult> GetActiveFishHashTable()
        {
            // Getting weather data through the existing GetWeatherHashTable method
            var weatherHashTableResult = await GetWeatherHashTable() as OkObjectResult;

            if (weatherHashTableResult == null)
            {
                return StatusCode(500, "Failed to retrieve weather data");
            }

            var weatherDataHashTable = weatherHashTableResult.Value as Hashtable;
            if (weatherDataHashTable == null)
            {
                return StatusCode(500, "Invalid weather data format");
            }

            // Creating a hash table to store active fish
            var activeFishHashTable = new Hashtable();

            // Going through all the elements in the table with weather data
            foreach (DictionaryEntry entry in weatherDataHashTable)
            {
                // Retrieving date (key) and weather data (value)
                var date = (DateTime)entry.Key;
                var weatherInfo = (WeatherData)entry.Value;

                // Selection of active fish for the current day
                var activeFish = _context.Fishes
                    .Where(fish => fish.TemperatureMin <= weatherInfo.MaxTemperature && fish.TemperatureMax >= weatherInfo.MinTemperature &&
                                   fish.PressureMin <= weatherInfo.AveragePressure && fish.PressureMax >= weatherInfo.AveragePressure)
                    .Select(fish => fish.Name)
                    .ToList();

                // If active fish are found, add them to the hash table, otherwise add "no active fish found"
                if (activeFish.Any())
                {
                    activeFishHashTable.Add(date, string.Join(", ", activeFish));
                }
                else
                {
                    activeFishHashTable.Add(date, "no active fish found");
                }
            }

            // Returning the result in JSON format
            return Ok(activeFishHashTable);
        }
    }
}