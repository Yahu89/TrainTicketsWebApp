namespace TrainTicketsWebApp.Database.Entities;

public class Route
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<RouteDetail> RouteDetails { get; set; } = new List<RouteDetail>();
    public List<Trip> Trips { get; set; } = new List<Trip>();
}
