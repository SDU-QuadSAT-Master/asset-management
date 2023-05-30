using System.ComponentModel.DataAnnotations;

namespace asset_management.Models.Drones
{
    public class DroneCreateRequest
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
