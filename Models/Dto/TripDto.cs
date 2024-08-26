namespace TrainTicketsWebApp.Models.Dto;

public class TripDto
{
    public int Id { get; set; }
    public string RouteName { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime DepartureTime { get; set; }
    public string TrainType { get; set; }
}
