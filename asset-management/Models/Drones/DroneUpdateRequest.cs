using System.ComponentModel.DataAnnotations;

namespace asset_management.Models.Drones
{
    public class DroneUpdateRequest
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public string Model { get; set; }
    }
}
