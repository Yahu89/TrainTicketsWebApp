namespace TrainTicketsWebApp.Database.Entities;

public class TrainType
{
    public string LongName { get; set; }
    public string ShortName { get; set; }
    public int TotalPlacesAvailable { get; set; }
    public int Speed { get; set; }
    public List<Trip> Trips { get; set; } = new List<Trip>();
}
