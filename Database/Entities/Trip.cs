namespace TrainTicketsWebApp.Database.Entities;

public class Trip
{
    public int Id { get; set; }
    public int RouteId { get; set; }
    public Route Route { get; set; }
    public DateTime DepartureTime { get; set; }
    public string TrainTypeName { get; set; }
    public TrainType TrainType { get; set; }
    public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
