public class Drone
{
    public int DroneId { get; set; }
    public int OrganizationId { get; set; }

    public string? Model { get; set; }
    public DateTime? Created { get; set; } = DateTime.Now.ToUniversalTime();

    public virtual ICollection<FlightEntry> FlightsEntrys { get; set; } = new List<FlightEntry>();

}