using System.Text.Json.Serialization;

public class FlightEntry
{
    [JsonIgnore]
    public int FlightEntryId { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
    public string Pilot { get; set; }
    public int Hours { get; set; }
    
    [JsonIgnore]
    public int DroneId { get; set; }

}