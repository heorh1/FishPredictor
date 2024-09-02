using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FishPredictor.DB;

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
    }
}