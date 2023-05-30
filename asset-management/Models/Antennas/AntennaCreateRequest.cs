using System.ComponentModel.DataAnnotations;

namespace asset_management.Models.Antennas
{
    public class AntennaCreateRequest
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public string? Location { get; set; }
    }
}
