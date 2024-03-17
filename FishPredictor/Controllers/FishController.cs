using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishPredictor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishesController : ControllerBase
    {
        private readonly FishContext _context;

        public FishesController(FishContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public IActionResult GetAllFishes()
        {
            var fishes = _context.Fishes.ToList();
            return Ok(fishes);
        }

        // GET
        [HttpGet("{id}")]
        public IActionResult GetFishDetails(int id)
        {
            var fish = _context.Fishes.Find(id);

            if (fish == null)
            {
                return NotFound();
            }
            return Ok(fish);
        }

        // POST
        [HttpPost]
        public IActionResult CreateFish([FromBody] Fish fish)
        {
            _context.Fishes.Add(fish);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetFishDetails), new { id = fish.Id }, fish);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateFish(int id, [FromBody] Fish fish)
        {
            if (id != fish.Id)
            {
                return BadRequest();
            }

            _context.Entry(fish).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteFish(int id)
        {
            var fish = _context.Fishes.Find(id);

            if (fish == null)
            {
                return NotFound();
            }

            _context.Fishes.Remove(fish);
            _context.SaveChanges();

            return NoContent();
        }
    }
}