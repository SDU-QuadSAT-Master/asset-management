using System.ComponentModel.DataAnnotations;

namespace asset_management.Models.FlightEntrys
{
    public class FlightEntryCreateRequest
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }
        
        [Required]
        public string Pilot { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        public int DroneId { get; set; }
    }
}
