namespace TrainTicketsWebApp.Database.Entities;

public class Schedule
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public TrainStation StationFrom { get; set; }
    public string From { get; set; }
    public TrainStation StationTo { get; set; }
    public string To { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public Trip Trip { get; set; }
}
