using asset_management.Models.Drones;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;



namespace asset_management
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class DroneController : ControllerBase

    {
        private IDroneService _droneService;

        public DroneController(IDroneService droneService)
        {
            _droneService = droneService;

        }

        // GET: api/<DroneController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_droneService.GetAll()); ;
        }

        // GET api/<DroneController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_droneService.GetById(id));
        }

        // POST api/<DroneController>
        [HttpPost]
        public IActionResult Post([FromBody] DroneCreateRequest model)
        {
            var drone = _droneService.Create(model);

            return Ok(drone);
        }

        // PUT api/<DroneController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DroneUpdateRequest model)
        {
            var drone = _droneService.Update(id, model);
            return Ok(drone);
        }

        // DELETE api/<DroneController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _droneService.Delete(id);
            return Ok(new { message = $"Drone {id} deleted" });
        }
    }
}
