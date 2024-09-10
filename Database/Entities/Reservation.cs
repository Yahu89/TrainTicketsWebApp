namespace TrainTicketsWebApp.Database.Entities;

public class Reservation
{
    public int Id { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public TrainStation TrainStationFrom { get; set; }
    public string From { get; set; }
    public TrainStation TrainStationTo { get; set; }
    public string To { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string TrainType { get; set; }
    public int SeatNumber { get; set; }
}
