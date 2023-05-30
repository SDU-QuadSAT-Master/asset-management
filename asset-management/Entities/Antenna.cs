public class Antenna
{
    public int AntennaId { get; set; }

    public int OrganizationId { get; set; }

    public string? Title { get; set; }

    public string? Location { get; set; }

    public DateTime Created { get; set; } = DateTime.Now.ToUniversalTime();
}