namespace TrainTicketsWebApp.Database.Entities;

public class RouteDetail
{
    public int Id { get; set; }
    public int RouteId { get; set; }
    public Route Routes { get; set; }
    public int SegmentNumber { get; set; }
    public TrainStation StationFrom { get; set; }
    public string From { get; set; }
    public TrainStation StationTo { get; set; }
    public string To { get; set; }
    public int Distance { get; set; }
    public int MaxSpeed { get; set; }
}
