namespace PowerGuard.Models;

public class EnergyEvent
{
    public int Id { get; set; }
    public string Location { get; set; } = "";
    public DateTime Timestamp { get; set; }
    public int DurationMinutes { get; set; }
    public string Cause { get; set; } = "";
    public string Damage { get; set; } = "";
}
