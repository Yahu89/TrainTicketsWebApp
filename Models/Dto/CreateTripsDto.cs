namespace TrainTicketsWebApp.Models.Dto;

public class CreateTripsDto
{
    //public int Id { get; set; }
    public int RouteId { get; set; }
    public string DepartureDate { get; set; }
    public string DepartureTime { get; set; }
    public string TrainType { get; set; }
}
