using asset_management.Models.FlightEntrys;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asset_management.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class FlightEntryController : ControllerBase
    {

        private IFlightEntryService _flightEntryService;

        public FlightEntryController(IFlightEntryService flightEntryService)
        {
            _flightEntryService = flightEntryService;

        }
        // GET: api/<FlightEntry>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_flightEntryService.GetAll());
        }

        // GET api/<FlightEntry>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_flightEntryService.GetById(id));
        }

        // POST api/<FlightEntry>
        [HttpPost]
        public IActionResult Post([FromBody] FlightEntryCreateRequest model)
        {
            var fe = _flightEntryService.Create(model);
            return Ok(fe);
        }
    }
}
