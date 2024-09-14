namespace TrainTicketsWebApp.Models.Dto;

public class StationsPaginationResultView
{
    public int CurrentPage { get; set; }
    public List<TrainStationDto> Stations { get; set; }
    public int TotalPages { get; set; }
    public StationsPaginationResultView(int totalPages, List<TrainStationDto> stations, int currentPage)
    {
        CurrentPage = currentPage;
        Stations = stations;
        TotalPages = totalPages;
    }
}
