using TrainTicketsWebApp.Database.Entities;

namespace TrainTicketsWebApp.Models.Dto;

public class TripsPaginationResultView
{
    public List<TripDto> Trips { get; set; }
    public int CurrentPageNumber { get; set; }
    public int TotalPages { get; set; } = 5;
    public TripsPaginationResultView(List<TripDto> trips)
    {
        Trips = trips;
    }
}
