using Microsoft.AspNetCore.Mvc;

namespace FishPredictor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FishesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllFishes()
        {
            var fishes = FishData.GetFishData();
            return Ok(fishes);
        }

        [HttpGet("{name}")]
        public IActionResult GetFishDetails(string name)
        {
            var fish = FishData.GetFishData().SingleOrDefault(f => f.Name.ToLower() == name.ToLower());

            if (fish != null)
            {
                return Ok(fish);
            }
            return NotFound();
        }
    }
}
