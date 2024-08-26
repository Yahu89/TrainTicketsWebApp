namespace TrainTicketsWebApp.Models.Dto;

public class RouteDetailDto
{
    public string Name { get; set; }
    public int SegmentNumber { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Distance { get; set; }
    public int MaxSpeed { get; set; }
}
