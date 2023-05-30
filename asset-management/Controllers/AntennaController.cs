using asset_management.Models.Antennas;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace asset_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class AntennaController : ControllerBase
    {
        private IAntennaService _antennaService;

        public AntennaController(IAntennaService antennaService)
        {
            _antennaService = antennaService;

        }

        // GET: api/<AntennaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_antennaService.GetAll()); ;
        }

        // GET api/<AntennaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_antennaService.GetById(id));
        }

        // POST api/<AntennaController>
        [HttpPost]
        public IActionResult Post([FromBody] AntennaCreateRequest model)
        {
            var drone = _antennaService.Create(model);

            return Ok(drone);
        }

        // PUT api/<AntennaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AntennaUpdateRequest model)
        {
            var drone = _antennaService.Update(id, model);
            return Ok(drone);
        }

        // DELETE api/<AntennaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _antennaService.Delete(id);
            return Ok(new { message = $"Antenna {id} deleted" });
        }
    }
}

