using asset_management.Models.Drones;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace asset_management
{

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class RabbitMQController : ControllerBase

    {

        // GET: api/<DroneController>
        [HttpPost]
        [Route("/drone/publish")]
        public IActionResult PublishDrone(int organizationId, string model)
        {
            Drone droneLog = new Drone() { OrganizationId = organizationId, Model = model};

            MessagePublisher publisher = new MessagePublisher("drones");
            publisher.PublishMessage(JsonConvert.SerializeObject(droneLog));
            publisher.Dispose();

            return Ok();

        }

        [HttpPost]
        [Route("/flightentry/publish")]
        public IActionResult PublishFlight(int droneId, int hours, string location)
        {
            FlightEntry flightEntry = new FlightEntry() { DroneId = droneId, Hours = hours, Location = location, Pilot = "Benjamin", Date = DateTime.Now.ToUniversalTime() };
        

            MessagePublisher publisher = new MessagePublisher("flights");
            publisher.PublishMessage(JsonConvert.SerializeObject(flightEntry));
            publisher.Dispose();

            return Ok();

        }

    }
}
