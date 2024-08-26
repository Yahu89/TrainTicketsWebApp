namespace TrainTicketsWebApp.Models.Dto;

public class CreateRouteDetailsDto
{
    public int RouteId { get; set; }
    public int SegmentNumber { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Distance { get; set; }
    public int MaxSpeed { get; set; }
}
