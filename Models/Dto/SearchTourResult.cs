namespace TrainTicketsWebApp.Models.Dto;

public class SearchTourResult
{
    public int TripId { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public int PlacesAvailable { get; set; }
    public string TrainType { get; set; }
    public int SegmentNumberFrom { get; set; }
    public int SegmentNumberTo { get; set; }
}
